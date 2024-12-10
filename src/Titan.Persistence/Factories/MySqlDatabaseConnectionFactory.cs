using MySqlConnector;
using System.Data;
using Titan.Persistence.Factories.Base;

namespace Titan.Persistence.Factories;

public sealed class MySqlDatabaseConnectionFactory : IDatabaseConnectionFactory
{
    public IDbConnection CreateConnection(string connectionString)
        => new MySqlConnection(connectionString);
}

