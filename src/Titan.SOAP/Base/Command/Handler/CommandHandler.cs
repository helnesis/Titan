namespace Titan.SOAP.Base.Command.Handler;


public sealed class CommandHandler(GameCommandCallback callback)
{
    public AuthCommand Auth => new(callback);
    
    public WorldCommand World => new(callback);
}