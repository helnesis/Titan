using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;
using Titan.Domain.Enums;
using Titan.Persistence.Repositories.Base;

namespace Titan.Persistence.Repositories.Interfaces;

public interface IItemRepository : IRepository<ItemTemplate>
{
    Task<Item?> GetItemDefinitionAsync(Identifier identifier);
    
    Task<ItemSparse?> GetItemSparseAsync(Identifier identifier);
    
    Task<ItemNameDescription?> GetItemNameDescriptionAsync(Identifier identifier);
    
    Task<IReadOnlyDictionary<Locale, ItemSparseLocale>?> GetItemSparseLocalesAsync(Identifier identifier);
    
    Task<IReadOnlyDictionary<Locale, ItemNameDescriptionLocale>?> GetItemNameDescriptionLocalesAsync(Identifier identifier);
    
    Task<ItemAppearance?> GetItemAppearanceAsync(Identifier identifier);
    
    Task<ItemModifiedAppearance?> GetItemModifiedAppearanceAsync(Identifier identifier);
    
    Task<ItemModifiedAppearanceExtra?> GetItemModifiedAppearanceExtraAsync(Identifier identifier);
}