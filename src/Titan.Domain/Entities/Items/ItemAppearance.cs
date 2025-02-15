using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Items;
using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Items;

public sealed record ItemAppearance : Entity
{
    [JsonConstructor]
    internal ItemAppearance(
        Identifier identifier,
        int displayType,
        int itemDisplayInfoId,
        int defaultIconFileDataId,
        int uiOrder,
        int playerConditionId)
        : base(identifier) => (
        DisplayType,
        ItemDisplayInfoId,
        DefaultIconFileDataId,
        UiOrder,
        PlayerConditionId
    ) = (
        displayType,
        itemDisplayInfoId,
        defaultIconFileDataId,
        uiOrder,
        playerConditionId
    );


    [JsonPropertyName("displayType")]
    public int DisplayType { get; init; }

    [JsonPropertyName("itemDisplayInfoId")]
    public int ItemDisplayInfoId { get; init; }

    [JsonPropertyName("defaultIconFileDataId")]
    public int DefaultIconFileDataId { get; init; }

    [JsonPropertyName("uiOrder")]
    public int UiOrder { get; init; }

    [JsonPropertyName("playerConditionId")]
    public int PlayerConditionId { get; init; }

    public static IItemAppearanceBuilder Builder => new ItemAppearanceBuilder();
}