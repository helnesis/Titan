using Dapper;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Persistence.Repositories.Interfaces;

namespace Titan.Persistence.Repositories.Implementations;

public sealed class CreatureRepository(DatabaseConnectionMgr connectionMgr) : ICreatureRepository
{
    public async Task CreateAsync(CreatureTemplate entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(CreatureTemplate entity)
    {
        using var connection = connectionMgr.GetWorldDatabase();
        return connection.ExecuteAsync(
            "DELETE FROM creature_template WHERE entry = @Entry",
            new { Entry = entity.Identifier }
        );
    }

    public Task<CreatureTemplate?> GetAsync(Identifier entityIdentifier)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CreatureTemplate entity)
    {
        throw new NotImplementedException();
    }
}