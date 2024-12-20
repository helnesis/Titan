using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Enums;
using Titan.Persistence.Repositories.Base;

namespace Titan.Persistence.Repositories.Interfaces;

public interface ICreatureRepository : IRepository<CreatureTemplate>
{
    /// <summary>
    /// Retrieves localized information for creatures, including names, descriptions, and other details.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains a dictionary where the key is the locale and the value is the corresponding localized creature information.
    /// </returns>
    Task<IReadOnlyDictionary<Locale, CreatureTemplateLocale>> GetCreatureLocalesAsync(Identifier creatureEntry);

    /// <summary>
    /// Retrieves models for creatures, including display identifier, display scale and other details.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a set of creature models.
    /// </returns>
    Task<IReadOnlyCollection<CreatureTemplateModel>> GetCreatureModelsAsync(Identifier creatureEntry);

    /// <summary>
    /// Retrieves creature spells, including spell identifier, spell indexes, and other details.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a set of creature spells.
    /// </returns>
    Task<IReadOnlyCollection<CreatureTemplateSpell>> GetCreatureSpellsAsync(Identifier creatureEntry);

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
    Task<CreatureTemplateOutfits?> GetCreatureOutfitsAsync(Identifier creatureEntry);


    /// <summary>
    /// Retrieves all creatures from the database that match the provided filter.
    /// </summary>
    /// <param name="filter">Creature name</param>
    /// <returns>A collection of creatures</returns>
    Task<IReadOnlyCollection<CreatureTemplate>> GetByName(string filter);
}

