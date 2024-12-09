namespace Titan.Persistence.Enums;

public enum DatabaseType
{
    /// <summary>
    /// The target database is the authentication database.
    /// </summary>
    AuthDatabase,

    /// <summary>
    /// The target database is the character database.
    /// </summary>
    CharacterDatabase,

    /// <summary>
    /// The target database is the world database.
    /// </summary>
    WorldDatabase,

    /// <summary>
    /// The target database is the hotfixes database.
    /// </summary>
    HotfixesDatabase,
}