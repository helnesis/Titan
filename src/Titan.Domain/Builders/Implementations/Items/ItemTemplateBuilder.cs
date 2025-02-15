using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;
using Titan.Domain.Enums;

namespace Titan.Domain.Builders.Implementations.Items;

public sealed class ItemTemplateBuilder : IItemTemplateBuilder
{
    private Item? _itemDefinition;
    
    private ItemSparse? _itemSparse;
    
    private ItemNameDescription? _itemNameDescription;
    
    private IReadOnlyDictionary<Locale, ItemSparseLocale>? _locales;
    
    private IReadOnlyDictionary<Locale, ItemNameDescriptionLocale>? _nameDescriptionLocales;
    
    private ItemAppearance? _appearance;
    
    private ItemModifiedAppearance? _modifiedAppearance;
    
    private ItemModifiedAppearanceExtra? _modifiedAppearanceExtra;
    public Identifier Identifier { get; private set; }
    public ItemTemplate Build()
    {
        return new ItemTemplate(Identifier,
            _itemDefinition,
            _itemSparse,
            _itemNameDescription,
            _locales,
            _nameDescriptionLocales,
            _appearance,
            _modifiedAppearance,
            _modifiedAppearanceExtra);
    }

    public IItemTemplateBuilder WithIdentifier(Identifier identifier)
    {
       Identifier = identifier;
         return this;
    }

    public IItemTemplateBuilder WithDefinition(Item? itemDefinition)
    {
        _itemDefinition = itemDefinition;
        return this;
    }

    public IItemTemplateBuilder WithSparse(ItemSparse? itemSparse)
    {
        _itemSparse = itemSparse;
        return this;
    }

    public IItemTemplateBuilder WithNameDescription(ItemNameDescription? itemNameDescription)
    {
        _itemNameDescription = itemNameDescription;
        return this;
    }

    public IItemTemplateBuilder WithSparseLocales(IReadOnlyDictionary<Locale, ItemSparseLocale>? locales)
    {
        _locales = locales;
        return this;
    }

    public IItemTemplateBuilder WithNameDescriptionLocales(IReadOnlyDictionary<Locale, ItemNameDescriptionLocale>? locales)
    {
        _nameDescriptionLocales = locales;
        return this;
    }

    public IItemTemplateBuilder WithAppearance(ItemAppearance? appearance)
    {
        _appearance = appearance;
        return this;
    }

    public IItemTemplateBuilder WithModifiedAppearance(ItemModifiedAppearance? modifiedAppearance)
    {
        _modifiedAppearance = modifiedAppearance;
        return this;
    }

    public IItemTemplateBuilder WithModifiedAppearanceExtra(ItemModifiedAppearanceExtra? modifiedAppearanceExtra)
    {
        _modifiedAppearanceExtra = modifiedAppearanceExtra;
        return this;
    }
}