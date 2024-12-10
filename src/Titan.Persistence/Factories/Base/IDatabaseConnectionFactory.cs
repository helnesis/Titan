using System.Data;

namespace Titan.Persistence.Factories.Base
{
    public interface IDatabaseConnectionFactory<out T> where T : IDbConnection
    {
        T CreateConnection(string databaseConnectionInfo);
    }
}
