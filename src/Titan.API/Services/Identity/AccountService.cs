using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using Titan.API.Converters;
using Titan.API.Models;
using Titan.API.Models.Requests;
using Titan.API.Models.Responses;
using Titan.API.Services.Misc;
using Titan.SOAP.Base.Client;

namespace Titan.API.Services.Identity;

public sealed class AccountService(IConfiguration configuration, RsaService rsaService, TrinitySoap soapClient, IHttpClientFactory httpClient)
{
    private const string GameAccountsEndpoint = "/bnetserver/gameAccounts/";
    
    private const string PortalEndpoint = "/bnetserver/portal/";
    
    private const string LoginEndpoint = "/bnetserver/login/";
    
    private const string RefreshLoginTicketEndpoint = "/bnetserver/refreshLoginTicket/";
    
    private readonly JsonSerializerOptions _serializerOptions =
        new() { Converters = { new AuthenticationStateJsonConverter() } };
    

    private static HttpRequestMessage CreateRequest(string httpEndpoint, string gameToken, HttpMethod httpMethod)
    {
        var request = new HttpRequestMessage(
            method: httpMethod,
            requestUri: httpEndpoint
        );
        
        request.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes(gameToken))}");
        
        return request;
    }
    
    
    /// <summary>
    /// Creates a new account through the TrinityCore SOAP API.
    /// </summary>
    /// <param name="request">Request data which contains credentials.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the result of the operation.
    /// It returns an <see cref="Ok{T}"/> result if the account was created successfully, otherwise an <see cref="InternalServerError"/> result.
    /// </returns>
    public async Task<Results<Ok<string>, InternalServerError>> Register(RegistrationRequestData request)
    {
        var decrypted = rsaService.Decrypt(request.Password);
        
        if (decrypted.Length == 0)
            return TypedResults.InternalServerError();
        
        var clearPassword = Encoding.UTF8.GetString(decrypted);
        var response = await soapClient.CommandHandler.Auth.CreateAccountAsync(request.Username, Encoding.UTF8.GetString(decrypted));
                
        return response.IsSuccess ? TypedResults.Ok(response.Result) : TypedResults.InternalServerError();
    }

    /// <summary>
    /// Get the portal through the TrinityCore SOAP API.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the result of the operation.
    /// The result is an <see cref="Ok{T}"/> result if the portal was retrieved successfully, otherwise an <see cref="InternalServerError"/> result.
    /// </returns>
    public async Task<Results<Ok<string>, InternalServerError>> GetPortal()
    {
        using var client = httpClient.CreateClient("TrinityCore");

        var portal = await client.GetStringAsync(PortalEndpoint);
        
        return TypedResults.Ok(portal);
    }

    /// <summary>
    /// Get the game accounts through the TrinityCore SOAP API.
    /// </summary>
    /// <param name="gameToken">TrinityCore game token</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the result of the operation.
    /// The result is an <see cref="Ok{T}"/> result if the game accounts were retrieved successfully, otherwise an <see cref="InternalServerError"/> result.
    /// </returns>
    public async Task<Results<Ok<GameAccountList>, ProblemHttpResult>> GetGameAccounts(string? gameToken)
    {
        if (gameToken is null)
            return TypedResults.Problem(
                title: "Unauthorized",
                statusCode: StatusCodes.Status401Unauthorized,
                detail: "The request is unauthorized, the game token is missing.",
                type: "https://datatracker.ietf.org/doc/html/rfc9110#section-15.5.2"
            );
        
        using var client = httpClient.CreateClient("TrinityCore");
        
        var request = CreateRequest(GameAccountsEndpoint, gameToken, HttpMethod.Get);
        var response = await client.SendAsync(request);
        
        if (!response.IsSuccessStatusCode)
            return TypedResults.Problem(
                title: "Not Found",
                statusCode: StatusCodes.Status500InternalServerError,
                detail: "The game accounts request has failed, the server has returned an unexpected response, the service is maybe down. Try again later.",
                type: "https://datatracker.ietf.org/doc/html/rfc9110#section-15.5.5"
            );
        
        var accounts = await response.Content.ReadFromJsonAsync<GameAccountList>();
        
        return TypedResults.Ok(accounts);
    }
    
    /// <summary>
    /// Authenticates a user through the TrinityCore SOAP API and returns a JWT token which identifies the user.
    /// </summary>
    /// <param name="loginRequest">Request data which contains credentials.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the result of the operation.
    /// The result is an <see cref="Ok{T}"/> result if the user was authenticated successfully, otherwise a <see cref="NotFound"/> result.
    /// </returns>
    public async Task<Results<Ok<LoginResponse>, ProblemHttpResult>> Authenticate(LoginRequestData loginRequest)
    {
        var decrypted = rsaService.Decrypt(loginRequest.Password);
        
        if (decrypted.Length == 0)
            return TypedResults.Problem( 
                title: "Bad Request",
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Password decryption has failed, check the provided structure or restart the application.",
                type: "https://datatracker.ietf.org/doc/html/rfc9110#section-15.5.1"
            );


        using var client = httpClient.CreateClient("TrinityCore");
        
        var request = await client.PostAsJsonAsync(LoginEndpoint, new LoginForm(
            PlatformId: Environment.OSVersion.VersionString,
            ProgramId: "Titan Web API",
            Version: "1.0.0.0",
            Inputs: [ 
                FormInputValue.WithAccount(loginRequest.Email), 
                FormInputValue.WithPassword(Encoding.UTF8.GetString(decrypted)) 
            ]
        ));
        
        
        if (!request.IsSuccessStatusCode)
            return TypedResults.Problem(
                title: "Not Found",
                statusCode: StatusCodes.Status404NotFound,
                detail: "The login request has failed, the username or password is incorrect, either the account does not exist.",
                type: "https://datatracker.ietf.org/doc/html/rfc9110#section-15.5.5"
            );
        
        
        var data = await request.Content.ReadFromJsonAsync<LoginResult>(options: _serializerOptions);

        if (data is { AuthenticationState: AuthenticationState.Done, LoginTicket: not null and not "" })
        {
            return TypedResults.Ok(new LoginResponse(
                ApiToken: CreateToken(loginRequest.Email, data.LoginTicket)
            ));
        }

        return TypedResults.Problem(
            title: "Internal Server Error",
            statusCode: StatusCodes.Status500InternalServerError,
            detail: "The login request has failed, the server has returned an unexpected response. Authentication service is maybe down. Try again later.",
            type: "https://datatracker.ietf.org/doc/html/rfc9110#section-15.6.1"
        );
    }
    
    /// <summary>
    /// Creates a JWT token that identifies the user. Payload parts contains the username and the game token.
    /// </summary>
    /// <param name="username">Username</param>
    /// <param name="gameToken">Login ticket (TrinityCore)</param>
    /// <returns>A JWT token</returns>
    private string CreateToken(string username, string gameToken)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, username),
            new(ClaimTypes.Sid, gameToken) //@TODO: Maybe use another claim type for the game token...
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Identity:Key")!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var descriptor = new JwtSecurityToken(
            issuer: configuration.GetValue<string>("Identity:Issuer"),
            audience: configuration.GetValue<string>("Identity:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(descriptor);
    }
    
}