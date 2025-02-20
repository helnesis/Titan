using DBCD;
using DBCD.Providers;
using Titan.DB2.Providers;
using Titan.DB2.Repositories.Records.Base;
using Titan.Domain.Entities;

namespace Titan.DB2.Repositories.Base;

public abstract class BaseRepository<T> : IDatabaseClientRepository<T> where T : DatabaseClientRecord
{
    private bool _isInitialized;
    
    private readonly string _repositoryFilePath;
    private readonly string _repositoryBuild;
    public IDBCDStorage? Storage { get; private set; }
    public RowConstructor? Rows { get; private set; }
    
    protected BaseRepository(string repositoryFilePath, string repositoryBuild)
    {
        _repositoryFilePath = repositoryFilePath;
        _repositoryBuild = repositoryBuild;
        
        Initialize();
    }
    
    public void Initialize()
    {
        if (_isInitialized)
            return;

        var dbcd = new DBCD.DBCD(new DatabaseClientProvider(_repositoryFilePath), new GithubDBDProvider());
        
        Storage = dbcd.Load(Path.GetFileNameWithoutExtension(_repositoryFilePath), _repositoryBuild);
        Rows = new RowConstructor(Storage);
        
        _isInitialized = true;
    }

    public void Save(string path) => Storage?.Save(path);
    
    
    public abstract bool Insert(T record);
    
    public abstract bool Update(T record);
    
    public abstract bool Delete(T record);
    
    public abstract T? Get(Identifier identifier);
}