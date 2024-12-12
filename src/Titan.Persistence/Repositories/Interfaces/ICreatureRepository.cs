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
    Task<IDictionary<Locale, CreatureTemplateLocale>> GetCreatureLocales();
}

