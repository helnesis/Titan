namespace Titan.SOAP.Base.Command.Definitions;

public enum GameCommand : byte
{
    CreateAccount,
    CreateGameAccount
}

public static class GameCommandDefinition
{
    private static GameCommandMap Commands => new()
    {
        { GameCommand.CreateAccount, "bnetaccount create " },
        { GameCommand.CreateGameAccount, "bnetaccount gameaccountcreate" }
    };
    
    public static string? GetCommand(GameCommand command)
    {
        return Commands.GetValueOrDefault(command);
    }
}