using Dapper;
using MySqlConnector;
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
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Identifier identifier)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<CreatureTemplate>> GetAllAsync()
    {
        throw new NotImplementedException();
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