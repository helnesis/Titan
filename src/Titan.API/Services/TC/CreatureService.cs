using Microsoft.AspNetCore.Http.HttpResults;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities.Creatures.Lookup;
using Titan.Domain.Enums;
using Titan.Persistence.Repositories.Interfaces;

namespace Titan.API.Services.TC;

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
    /// Retrieves base mana for a creature by its level and class.
    /// </summary>
    /// <param name="level">Creature level</param>
    /// <param name="unitClass">Creature class</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The result contains either an <see cref="Ok{T}"/> result with the base mana if found, or a <see cref="NotFound"/> result if the creature does not exist.
    /// </returns>
    public async Task<Results<Ok<int>, NotFound>> GetCreatureBaseMana(byte level, byte unitClass)
    {
        var baseMana = await creatureRepository.GetBaseManaByLevel(level, unitClass);
        
        return baseMana != -1 ? TypedResults.Ok(baseMana) : TypedResults.NotFound();
    }
    

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
    public async Task<Results<Ok<IReadOnlyDictionary<Locale, CreatureTemplateLocale>>, NotFound>> GetCreatureLocaleByIdentifier(Identifier identifier)
    {
        var creature = await creatureRepository.GetCreatureLocalesAsync(identifier);
        return creature is { Count: 0 }? TypedResults.NotFound() : TypedResults.Ok(creature);
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

        return creatures is { Count: 0 } ? TypedResults.NotFound() : TypedResults.Ok(creatures);
    }


    /// <summary>
    /// Retrieves a creature by its name.
    /// </summary>
    /// <param name="filter">Creature name</param>
    /// <param name="locale">Locale</param>
    /// <returns>A task that represents the asynchronous operation.
    /// The result contains either an <see cref="Ok{T}"/> result with a collection of <see cref="CreatureTemplate"/>
    /// if found, or a <see cref="NotFound"/> result if no creatures exist.
    /// </returns>
    public async Task<Results<Ok<IReadOnlyCollection<CreatureTemplate>>, NotFound>> GetCreatureByName(string filter, Locale locale = Locale.enGB)
    {
        var creatures = await creatureRepository.GetByName(filter);

        return creatures is { Count: 0 } ? TypedResults.NotFound() : TypedResults.Ok(creatures);
    }


    /// <summary>
    /// Retrieves a list of creatures, with their entry and name.
    /// </summary>
    /// <param name="locale">Locale</param>
    /// <returns>A task that represents the asynchronous operation.
    /// The result contains either an <see cref="Ok{T}"/> result with a collection of <see cref="CreatureLookup"/>
    /// </returns>
    public async Task<Results<Ok<IReadOnlyCollection<CreatureLookup>>, NotFound>> GetCreatureList(Locale locale = Locale.frFR)
    {
        var creatureList = await creatureRepository.GetCreaturesLookupAsync(locale);
        
        return creatureList is { Count: 0 } ? TypedResults.NotFound() : TypedResults.Ok(creatureList);
    }


    public async Task<Results<Ok<CreatureTemplate>, InternalServerError>> CreateCreature(CreatureTemplate creatureTemplate)
    {
        var creature = await creatureRepository.CreateAsync(creatureTemplate);
        return creature is null ? TypedResults.InternalServerError() : TypedResults.Ok(creature);
    }

}