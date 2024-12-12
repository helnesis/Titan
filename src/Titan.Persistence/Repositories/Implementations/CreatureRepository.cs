using Dapper;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Persistence.Repositories.Interfaces;

namespace Titan.Persistence.Repositories.Implementations;

public sealed class CreatureRepository(DatabaseProvider provider) : ICreatureRepository
{

    public async Task CreateAsync(CreatureTemplate entity)
    {
        await using var conn = provider.GetWorldDatabase();
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

    public async Task<CreatureTemplate?> GetAsync(Identifier entityIdentifier)
    {
        await using var conn = provider.GetWorldDatabase();

        // test for exception middleware
        await conn.ExecuteAsync("SELECT d FROM creature_template");

        return null;

    }

    public Task UpdateAsync(CreatureTemplate entity)
    {
        throw new NotImplementedException();
    }
}