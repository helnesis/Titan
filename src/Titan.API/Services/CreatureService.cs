using Microsoft.AspNetCore.Http.HttpResults;
using MySqlConnector;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Persistence.Repositories.Interfaces;

namespace Titan.API.Services;

public sealed class CreatureService(ICreatureRepository creatureRepository)
{
    public async Task<Results<Ok<CreatureTemplate>, NotFound, ProblemHttpResult>> GetCreature(Identifier identifier)
    {
        try {
            var creature = await creatureRepository.GetAsync(identifier);
            return creature is null ? TypedResults.NotFound() : TypedResults.Ok(creature);
        }
        catch (MySqlException) {

            return TypedResults.Problem(new ProblemBuilder()
                .WithStatusCode(StatusCodes.Status500InternalServerError)
                .WithTitle("Persistence Error")
                .WithDetails("The database is currently unavailable. Make sure the database is running and try again.")
                .WithInstance($"/creatures/{identifier}")
                .Build());
        }
    }
}