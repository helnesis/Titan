using System.Data;
using Titan.Persistence.Factories.Base;

namespace Titan.Persistence
{
    /// <summary>
    /// Handle database connections.
    /// </summary>
    /// <param name="connectionFactory">Factory</param>
    /// <param name="connectionInfo">Connection info</param>
    public sealed class DatabaseConnectionMgr(IDatabaseConnectionFactory connectionFactory, DatabaseConnectionInfo connectionInfo)
    {
        /// <summary>
        /// Returns a connection to the world database.
        /// </summary>
        public IDbConnection GetWorldDatabase() => connectionFactory.CreateConnection(connectionInfo.WorldDatabase);

        /// <summary>
        /// Returns a connection to the hotfixes database.
        /// </summary>
        public IDbConnection GetHotfixesDatabase() => connectionFactory.CreateConnection(connectionInfo.HotfixesDatabase);

        /// <summary>
        /// Returns a connection to the character database.
        /// </summary>
        public IDbConnection GetCharacterDatabase() => connectionFactory.CreateConnection(connectionInfo.CharacterDatabase);

        /// <summary>
        /// Returns a connection to the auth database.
        /// </summary>
        public IDbConnection GetAuthDatabase() => connectionFactory.CreateConnection(connectionInfo.AuthDatabase);
    }
}
