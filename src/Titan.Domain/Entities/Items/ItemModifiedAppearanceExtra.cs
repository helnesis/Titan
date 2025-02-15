using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Items;
using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities.Base;
namespace Titan.Domain.Entities.Items;

public sealed record ItemModifiedAppearanceExtra : Entity
{
    [JsonConstructor]
    internal ItemModifiedAppearanceExtra(
        Identifier identifier,
        int iconFileDataId,
        int unequippedIconFileDataId,
        byte sheatheType,
        sbyte displayWeaponSubclassId,
        sbyte displayInventoryType)
        : base(identifier) => (
        IconFileDataId,
        UnequippedIconFileDataId,
        SheatheType,
        DisplayWeaponSubclassId,
        DisplayInventoryType
    ) = (
        iconFileDataId,
        unequippedIconFileDataId,
        sheatheType,
        displayWeaponSubclassId,
        displayInventoryType
    );


    [JsonPropertyName("iconFileDataId")]
    public int IconFileDataId { get; init; }

    [JsonPropertyName("unequippedIconFileDataId")]
    public int UnequippedIconFileDataId { get; init; }

    [JsonPropertyName("sheatheType")]
    public byte SheatheType { get; init; }

    [JsonPropertyName("displayWeaponSubclassId")]
    public sbyte DisplayWeaponSubclassId { get; init; }

    [JsonPropertyName("displayInventoryType")]
    public sbyte DisplayInventoryType { get; init; }

    public static IItemModifiedAppearanceExtraBuilder Builder => new ItemModifiedAppearanceExtraBuilder();
}