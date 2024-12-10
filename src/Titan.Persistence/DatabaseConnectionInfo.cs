namespace Titan.Persistence;

public sealed record DatabaseConnectionInfo(string AuthDatabase, string CharacterDatabase, string WorldDatabase, string HotfixesDatabase);