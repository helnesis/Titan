using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;
using Titan.Domain.Enums;

namespace Titan.Domain.Builders.Interfaces.Items;

public interface IItemTemplateBuilder : IBuilder<ItemTemplate>
{
    IItemTemplateBuilder WithIdentifier(Identifier identifier);

    IItemTemplateBuilder WithDefinition(Item? itemDefinition);
    
    IItemTemplateBuilder WithSparse(ItemSparse? itemSparse);
    
    IItemTemplateBuilder WithNameDescription(ItemNameDescription? itemNameDescription);

    IItemTemplateBuilder WithSparseLocales(IReadOnlyDictionary<Locale, ItemSparseLocale>? locales);
    
    IItemTemplateBuilder WithNameDescriptionLocales(IReadOnlyDictionary<Locale, ItemNameDescriptionLocale>? locales);
    
    IItemTemplateBuilder WithAppearance(ItemAppearance? appearance);
    
    IItemTemplateBuilder WithModifiedAppearance(ItemModifiedAppearance? modifiedAppearance);
    
    IItemTemplateBuilder WithModifiedAppearanceExtra(ItemModifiedAppearanceExtra? modifiedAppearanceExtra);
}