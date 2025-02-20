using DBCD.Providers;

namespace Titan.DB2.Providers;

public sealed class DatabaseClientProvider(string directory) : IDBCProvider
{
    private readonly string _directory = directory;
    
    public Stream StreamForTableName(string tableName, string build) => File.OpenRead(Path.Combine(_directory, tableName + ".db2"));

}