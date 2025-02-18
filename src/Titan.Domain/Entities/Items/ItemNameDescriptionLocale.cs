using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Items;
using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities.Base;
using Titan.Domain.Enums;

namespace Titan.Domain.Entities.Items;

public sealed record ItemNameDescriptionLocale : Entity
{
    [JsonConstructor]
    internal ItemNameDescriptionLocale(
        Identifier identifier,
        string? locale,
        string? descriptionLang)
        : base(identifier) => (
        Locale,
        DescriptionLang
    ) = (
        locale,
        descriptionLang
    );

    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    [JsonPropertyName("descriptionLang")]
    public string? DescriptionLang { get; init; }

    public static IItemNameDescriptionLocaleBuilder Builder => new ItemNameDescriptionLocaleBuilder();
}