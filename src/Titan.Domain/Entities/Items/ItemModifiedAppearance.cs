using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Items;
using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Items;

public sealed record ItemModifiedAppearance : Entity
{
    [JsonConstructor]
    internal ItemModifiedAppearance(
        Identifier identifier,
        int itemId,
        int itemAppearanceModifierId,
        int itemAppearanceId,
        int orderIndex,
        byte transmogSourceTypeEnum,
        int flags)
        : base(identifier) => (
        ItemId,
        ItemAppearanceModifierId,
        ItemAppearanceId,
        OrderIndex,
        TransmogSourceTypeEnum,
        Flags
    ) = (
        itemId,
        itemAppearanceModifierId,
        itemAppearanceId,
        orderIndex,
        transmogSourceTypeEnum,
        flags
    );


    [JsonPropertyName("itemId")]
    public int ItemId { get; init; }

    [JsonPropertyName("itemAppearanceModifierId")]
    public int ItemAppearanceModifierId { get; init; }

    [JsonPropertyName("itemAppearanceId")]
    public int ItemAppearanceId { get; init; }

    [JsonPropertyName("orderIndex")]
    public int OrderIndex { get; init; }

    [JsonPropertyName("transmogSourceTypeEnum")]
    public byte TransmogSourceTypeEnum { get; init; }

    [JsonPropertyName("flags")]
    public int Flags { get; init; }

    public static IItemModifiedAppearanceBuilder Builder => new ItemModifiedAppearanceBuilder();
}