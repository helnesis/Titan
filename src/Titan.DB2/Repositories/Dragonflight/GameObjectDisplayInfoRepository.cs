using Titan.DB2.Repositories.Base;
using Titan.DB2.Repositories.Records.Base;
using Titan.Domain.Entities;

namespace Titan.DB2.Repositories.Dragonflight;

public sealed record A() : DatabaseClientRecord;


public sealed class GameObjectDisplayInfoRepository(string repositoryPath, string repositoryBuild) : BaseRepository<A>(repositoryPath, repositoryBuild)
{
    public override bool Insert(A record)
    {
        throw new NotImplementedException();
    }

    public override bool Update(A record)
    {
        throw new NotImplementedException();
    }

    public override bool Delete(A record)
    {
        throw new NotImplementedException();
    }

    public override A? Get(Identifier identifier)
    {
        throw new NotImplementedException();
    }
}