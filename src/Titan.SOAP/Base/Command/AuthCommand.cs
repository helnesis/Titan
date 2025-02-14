
namespace Titan.SOAP.Base.Command;

public sealed class AuthCommand(GameCommandCallback callback)
{
    public async Task<SoapResponse> CreateAccountAsync(string email, string password)
        => await callback.Invoke(GameCommand.CreateAccount, [email, password]);
    
    public async Task<SoapResponse> CreateGameAccountAsync(string email)
        => await callback.Invoke(GameCommand.CreateGameAccount, [email]);
}