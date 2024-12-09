namespace Titan.Persistence.Factories.Base;

public sealed record DatabaseConnectionInfo(string AuthDatabase, string CharacterDatabase, string WorldDatabase, string HotfixesDatabase);