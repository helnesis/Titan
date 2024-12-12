using Microsoft.AspNetCore.Http.HttpResults;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Persistence.Repositories.Interfaces;

namespace Titan.API.Services;

public sealed class CreatureService(ICreatureRepository creatureRepository)
{
    /// <summary>
    /// Returns the creature with the given identifier.
    /// </summary>
    /// <param name="identifier">Identifier</param>
    /// <returns>Creature</returns>
    public async Task<Results<Ok<CreatureTemplate>, NotFound>> GetCreature(Identifier identifier)
    {
        var creature = await creatureRepository.GetAsync(identifier);
        return creature is null ? TypedResults.NotFound() : TypedResults.Ok(creature);
    }
}