using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Enums;
using Titan.Persistence.Repositories.Interfaces;

namespace Titan.Persistence.Repositories.Implementations;

public sealed class CreatureRepository(DatabaseProvider provider) : ICreatureRepository
{
    public Task CreateAsync(CreatureTemplate entity)
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

    public Task<CreatureTemplateAddon> GetCreatureAddonAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IDictionary<Locale, CreatureTemplateLocale>> GetCreatureLocalesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlySet<CreatureTemplateModel>> GetCreatureModelsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CreatureTemplateOutfits> GetCreatureOutfitsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlySet<CreatureTemplateSpell>> GetCreatureSpellsAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CreatureTemplate entity)
    {
        throw new NotImplementedException();
    }
}