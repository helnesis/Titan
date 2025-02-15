using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Items;
using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Items;

public sealed record Item : Entity
{
    [JsonConstructor]
    internal Item(
        Identifier identifier,
        byte classId,
        byte subclassId,
        byte material,
        sbyte inventoryType,
        byte sheatheType,
        sbyte soundOverrideSubclassId,
        int iconFileDataId,
        byte itemGroupSoundsId,
        int contentTuningId,
        int modifiedCraftingReagentItemId,
        int craftingQualityId)
        : base(identifier) => (
        ClassId,
        SubclassId,
        Material,
        InventoryType,
        SheatheType,
        SoundOverrideSubclassId,
        IconFileDataId,
        ItemGroupSoundsId,
        ContentTuningId,
        ModifiedCraftingReagentItemId,
        CraftingQualityId
    ) = (
        classId,
        subclassId,
        material,
        inventoryType,
        sheatheType,
        soundOverrideSubclassId,
        iconFileDataId,
        itemGroupSoundsId,
        contentTuningId,
        modifiedCraftingReagentItemId,
        craftingQualityId
    );


    [JsonPropertyName("classId")]
    public byte ClassId { get; init; }

    [JsonPropertyName("subclassId")]
    public byte SubclassId { get; init; }

    [JsonPropertyName("material")]
    public byte Material { get; init; }

    [JsonPropertyName("inventoryType")]
    public sbyte InventoryType { get; init; }

    [JsonPropertyName("sheatheType")]
    public byte SheatheType { get; init; }

    [JsonPropertyName("soundOverrideSubclassId")]
    public sbyte SoundOverrideSubclassId { get; init; }

    [JsonPropertyName("iconFileDataId")]
    public int IconFileDataId { get; init; }

    [JsonPropertyName("itemGroupSoundsId")]
    public byte ItemGroupSoundsId { get; init; }

    [JsonPropertyName("contentTuningId")]
    public int ContentTuningId { get; init; }

    [JsonPropertyName("modifiedCraftingReagentItemId")]
    public int ModifiedCraftingReagentItemId { get; init; }

    [JsonPropertyName("craftingQualityId")]
    public int CraftingQualityId { get; init; }

    public static IItemBuilder Builder => new ItemBuilder();
}