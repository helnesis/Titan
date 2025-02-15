using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Items;
using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Items;

public sealed record ItemNameDescription : Entity
{
    [JsonConstructor]
    internal ItemNameDescription(
        Identifier identifier,
        string? description,
        int color)
        : base(identifier) => (
        Description,
        Color
    ) = (
        description,
        color
    );


    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("color")]
    public int Color { get; init; }

    public static IItemNameDescriptionBuilder Builder => new ItemNameDescriptionBuilder();
}