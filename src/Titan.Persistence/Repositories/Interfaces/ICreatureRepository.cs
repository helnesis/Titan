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
    Task<IDictionary<Locale, CreatureTemplateLocale>> GetCreatureLocalesAsync();

    /// <summary>
    /// Retrieves models for creatures, including display identifier, display scale and other details.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a set of creature models.
    /// </returns>
    Task<IReadOnlySet<CreatureTemplateModel>> GetCreatureModelsAsync();

    /// <summary>
    /// Retrieves creature spells, including spell identifier, spell indexes, and other details.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a set of creature spells.
    /// </returns>
    Task<IReadOnlySet<CreatureTemplateSpell>> GetCreatureSpellsAsync();

    /// <summary>
    /// Retrieves creature addons, including auras, mounts, weapons and other details.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains creature's addons.
    /// </returns>
    Task<CreatureTemplateAddon> GetCreatureAddonAsync();

    /// <summary>
    /// Retrieves creature outfits, including armor and other details.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains creature's outfits.
    /// </returns>
    Task<CreatureTemplateOutfits> GetCreatureOutfitsAsync();
}

