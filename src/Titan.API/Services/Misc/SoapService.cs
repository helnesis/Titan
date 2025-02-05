using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Titan.SOAP.Base.Client;

namespace Titan.API.Services.Misc;


public sealed record AccountRegistrationRequest(string Email, byte[] Password);

public class SoapService(TrinitySoap client, RsaService rsaService)
{
    public async Task<Results<Ok<string>, InternalServerError>> CreateAccount(AccountRegistrationRequest request)
    {
        var decrypted = rsaService.Decrypt(request.Password);
        
        if (decrypted.Length == 0)
            return TypedResults.InternalServerError();
        
        var response = await client.AuthCommand.CreateAccountAsync(request.Email, Encoding.UTF8.GetString(decrypted));
        
        return response.IsSuccess ? TypedResults.Ok(response.Result) : TypedResults.InternalServerError();
    }
}