using MySqlConnector;
using Titan.Persistence.Factories.Base;

namespace Titan.Persistence.Factories;

public sealed class MySqlDatabaseConnectionFactory : IDatabaseConnectionFactory<MySqlConnection>
{
    public MySqlConnection CreateConnection(string databaseConnectionInfo)
        => new (databaseConnectionInfo);
}

