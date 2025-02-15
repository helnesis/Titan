using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Items;
using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities.Base;
using Titan.Domain.Enums;

namespace Titan.Domain.Entities.Items;

public sealed record ItemSparseLocale : Entity
{
    [JsonConstructor]
    internal ItemSparseLocale(
        Identifier identifier,
        Locale locale,
        string? descriptionLang,
        string? display3Lang,
        string? display2Lang,
        string? display1Lang,
        string? displayLang)
        : base(identifier) => (
        DescriptionLang,
        Display3Lang,
        Display2Lang,
        Display1Lang,
        DisplayLang
    ) = (
        descriptionLang,
        display3Lang,
        display2Lang,
        display1Lang,
        displayLang
    );
    
    
    [JsonPropertyName("locale")]
    public Locale Locale { get; init; }

    [JsonPropertyName("descriptionLang")]
    public string? DescriptionLang { get; init; }

    [JsonPropertyName("display3Lang")]
    public string? Display3Lang { get; init; }

    [JsonPropertyName("display2Lang")]
    public string? Display2Lang { get; init; }

    [JsonPropertyName("display1Lang")]
    public string? Display1Lang { get; init; }

    [JsonPropertyName("displayLang")]
    public string? DisplayLang { get; init; }

    public static IItemSparseLocaleBuilder Builder => new ItemSparseLocaleBuilder();
}