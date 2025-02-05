using Titan.SOAP.Base.Client;

namespace Titan.SOAP.Base.Command;

public sealed class AuthCommand(ISoapClient client)
{
    /// <summary>
    /// Create a new Battle.net account.
    /// </summary>
    /// <param name="email">Account email</param>
    /// <param name="password">Account password</param>
    /// <returns>Request response</returns>
    public async Task<SoapResponse> CreateAccountAsync(string email, string password)
       => await client.SendAsync("bnetaccount create", email, password);
    
    /// <summary>
    /// Create additional game account for specified Battle.net account.
    /// </summary>
    /// <param name="email">Battle.net account</param>
    /// <returns>Request response</returns>
    public async Task<SoapResponse> CreateGameAccountAsync(string email)
        => await client.SendAsync("bnetaccount gameaccountcreate", email);
}