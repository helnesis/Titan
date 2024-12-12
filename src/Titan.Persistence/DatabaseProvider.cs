using MySqlConnector;
using Titan.Persistence.Factories.Base;

namespace Titan.Persistence
{
    /// <summary>
    /// Provides methods to retrieve connections to the various databases.
    /// </summary>
    /// <param name="connectionFactory">Database connection factory.</param>
    /// <param name="connectionInfo">Database connection info.</param>
    public sealed class DatabaseProvider(IDatabaseConnectionFactory<MySqlConnection> connectionFactory, DatabaseConnectionInfo connectionInfo)
    {
        /// <summary>
        /// Returns a connection to the world database.
        /// </summary>
        public MySqlConnection GetWorldDatabase() => connectionFactory.CreateConnection(connectionInfo.WorldDatabase);

        /// <summary>
        /// Returns a connection to the hotfixes database.
        /// </summary>
        public MySqlConnection GetHotfixesDatabase() => connectionFactory.CreateConnection(connectionInfo.HotfixesDatabase);

        /// <summary>
        /// Returns a connection to the character database.
        /// </summary>
        public MySqlConnection GetCharacterDatabase() => connectionFactory.CreateConnection(connectionInfo.CharacterDatabase);

        /// <summary>
        /// Returns a connection to the auth database.
        /// </summary>
        public MySqlConnection GetAuthDatabase() => connectionFactory.CreateConnection(connectionInfo.AuthDatabase);
    }
}
