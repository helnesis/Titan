using Microsoft.AspNetCore.Http.HttpResults;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Persistence.Repositories.Interfaces;

namespace Titan.API.Services;

public sealed class CreatureService(ICreatureRepository creatureRepository)
{
    /// <summary>
    /// Retrieves a creature by its unique identifier.
    /// </summary>
    /// <param name="identifier">
    /// The unique identifier of the creature to retrieve.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The result contains either an <see cref="Ok{T}"/> result with the <see cref="CreatureTemplate"/> 
    /// if found, or a <see cref="NotFound"/> result if the creature does not exist.
    /// </returns>
    public async Task<Results<Ok<CreatureTemplate>, NotFound>> GetCreatureByIdentifier(Identifier identifier)
    {
        var creature = await creatureRepository.GetAsync(identifier);
        return creature is null ? TypedResults.NotFound() : TypedResults.Ok(creature);
    }

    /// <summary>
    /// Retrieves all creatures.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The result contains either an <see cref="Ok{T}"/> result with a collection of <see cref="CreatureTemplate"/>
    /// if found, or a <see cref="NotFound"/> result if no creatures exist.
    /// </returns>

    public async Task<Results<Ok<IReadOnlyCollection<CreatureTemplate>>, NotFound>> GetAllCreatures()
    {
        var creatures = await creatureRepository.GetAllAsync();

        return creatures is null ? TypedResults.NotFound() : TypedResults.Ok(creatures);
    }

}