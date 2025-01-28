using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities.Creatures.Lookup;
using Titan.Domain.Enums;
using Titan.Persistence.Repositories.Base;

namespace Titan.Persistence.Repositories.Interfaces;

public interface ICreatureRepository : IRepository<CreatureTemplate>
{

    /// <summary>
    /// Retrieves a collection of creatures from the database, as a tuple of creature entry and creature name.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a collection of creature entries and names.
    /// </returns>
    Task<IReadOnlyCollection<CreatureLookup>?> GetCreaturesLookupAsync(Locale locale);
    
    /// <summary>
    /// Retrieves localized information for creatures, including names, descriptions, and other details.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains a dictionary where the key is the locale and the value is the corresponding localized creature information.
    /// </returns>
    Task<IReadOnlyDictionary<Locale, CreatureTemplateLocale>?> GetCreatureLocalesAsync(Identifier creatureEntry);

    /// <summary>
    /// Retrieves models for creatures, including display identifier, display scale and other details.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a set of creature models.
    /// </returns>
    Task<IReadOnlyCollection<CreatureTemplateModel>?> GetCreatureModelsAsync(Identifier creatureEntry);

    /// <summary>
    /// Retrieves creature spells, including spell identifier, spell indexes, and other details.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a set of creature spells.
    /// </returns>
    Task<IReadOnlyCollection<CreatureTemplateSpell>?> GetCreatureSpellsAsync(Identifier creatureEntry);

    /// <summary>
    /// Retrieves creature addons, including auras, mounts, weapons and other details.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains creature's addons.
    /// </returns>
    Task<CreatureTemplateAddon?> GetCreatureAddonAsync(Identifier creatureEntry);

    /// <summary>
    /// Retrieves creature outfits, including armor and other details.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains creature's outfits.
    /// </returns>
    Task<IReadOnlyCollection<CreatureTemplateOutfits>?> GetCreatureOutfitsAsync(Identifier creatureEntry);
    
    /// <summary>
    /// Retrieves creature sparrings.
    /// </summary>
    /// <param name="creatureEntry">Creature's entry.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains creature's sparrings.
    /// </returns>
    Task<IReadOnlyCollection<CreatureTemplateSparring>?> GetCreatureSparringAsync(Identifier creatureEntry);
    
    /// <summary>
    /// Retrieves creature equipments.
    /// </summary>
    /// <param name="creatureEntry">Creature's entry.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains creature's equipments.
    /// </returns>
    Task<IReadOnlyCollection<CreatureEquipTemplate?>> GetCreatureEquipmentsAsync(Identifier creatureEntry);
    
    /// <summary>
    /// Retrieves creature gossips.
    /// </summary>
    /// <param name="creatureEntry">Creature's entry.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains creature's gossips.
    /// </returns>
    Task<IReadOnlyCollection<CreatureTemplateGossip?>> GetCreatureGossipsAsync(Identifier creatureEntry);
    
    /// <summary>
    /// Retrieves creature flags.
    /// </summary>
    /// <param name="creatureEntry">Creature's entry.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains creature's flags.
    /// </returns>
    Task<CreatureTemplateFlags?> GetCreatureFlagsAsync(Identifier creatureEntry);
    
    /// <summary>
    /// Retrieves creature movements.
    /// </summary>
    /// <param name="creatureEntry">Creature's entry.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains creature's movements.
    /// </returns>
    Task<CreatureTemplateMovement?> GetCreatureMovementAsync(Identifier creatureEntry);

    /// <summary>
    /// Retrieves creature resistances.
    /// </summary>
    /// <param name="creatureEntry">Creature's entry.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains creature's movements.
    /// </returns>
    Task<IReadOnlyCollection<CreatureTemplateResistance>?> GetCreatureResistancesAsync(Identifier creatureEntry);
    
    /// <summary>
    /// Retrieves creature difficulties.
    /// </summary>
    /// <param name="creatureEntry">Creature's entry.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains creature's difficulties.
    /// </returns>
    Task<IReadOnlyCollection<CreatureTemplateDifficulty>?> GetCreatureDifficultiesAsync(Identifier creatureEntry);
    
    /// <summary>
    /// Retrieves all creatures from the database that match the provided filter.
    /// </summary>
    /// <param name="filter">Creature name</param>
    /// <returns>A collection of creatures</returns>
    Task<IReadOnlyCollection<CreatureTemplate>?> GetByName(string filter);
}

