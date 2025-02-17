using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Items;
using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities.Base;
using Titan.Domain.Enums;

namespace Titan.Domain.Entities.Items;

public sealed record ItemTemplate : Entity
{
    [JsonPropertyName("itemDefinition")]
    public Item? Definition { get; init; }
    
    [JsonPropertyName("itemSparse")]
    public ItemSparse? Sparse { get; init; }
    
    [JsonPropertyName("itemNameDescription")]
    public ItemNameDescription? NameDescription { get; init; }
    
    [JsonPropertyName("itemSparseLocales")]
    public IReadOnlyDictionary<Locale, ItemSparseLocale>? SparseLocales { get; init; }
    
    [JsonPropertyName("itemNameDescriptionLocales")]
    public IReadOnlyDictionary<Locale, ItemNameDescriptionLocale>? NameDescriptionLocales { get; init; }
    
    [JsonPropertyName("itemAppearance")]
    public ItemAppearance? Appearance { get; init; }
    
    [JsonPropertyName("itemModifiedAppearance")]
    public ItemModifiedAppearance? ModifiedAppearance { get; init; }
    
    [JsonPropertyName("itemModifiedAppearanceExtra")]
    public ItemModifiedAppearanceExtra? ModifiedAppearanceExtra { get; init; }
    
    [JsonConstructor]
    internal ItemTemplate(
        Identifier identifier,
        Item? definition,
        ItemSparse? sparse,
        ItemNameDescription? nameDescription,
        IReadOnlyDictionary<Locale, ItemSparseLocale>? sparseLocales,
        IReadOnlyDictionary<Locale, ItemNameDescriptionLocale>? nameDescriptionLocales,
        ItemAppearance? appearance,
        ItemModifiedAppearance? modifiedAppearance,
        ItemModifiedAppearanceExtra? modifiedAppearanceExtra)
        : base(identifier) => (
        Definition,
        Sparse,
        NameDescription,
        SparseLocales,
        NameDescriptionLocales,
        Appearance,
        ModifiedAppearance,
        ModifiedAppearanceExtra
    ) = (
        definition,
        sparse,
        nameDescription,
        sparseLocales,
        nameDescriptionLocales,
        appearance,
        modifiedAppearance,
        modifiedAppearanceExtra
    );
    
    public static IItemTemplateBuilder Builder => new ItemTemplateBuilder();
}