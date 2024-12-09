using System.Data;

namespace Titan.Persistence.Factories.Base
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection CreateConnection(string databaseConnectionInfo);
    }
}
