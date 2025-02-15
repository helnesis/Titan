using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Items;
using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Items;

public sealed record ItemNameDescriptionLocale : Entity
{
    [JsonConstructor]
    internal ItemNameDescriptionLocale(
        Identifier identifier,
        string? descriptionLang)
        : base(identifier) => (
        DescriptionLang
    ) = (
        descriptionLang
    );


    [JsonPropertyName("descriptionLang")]
    public string? DescriptionLang { get; init; }

    public static IItemNameDescriptionLocaleBuilder Builder => new ItemNameDescriptionLocaleBuilder();
}