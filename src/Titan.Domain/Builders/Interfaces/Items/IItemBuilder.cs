using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Interfaces.Items;

public interface IItemBuilder : IBuilder<Item>
{
    IItemBuilder WithIdentifier(Identifier identifier);

    IItemBuilder WithClassId(byte classId);

    IItemBuilder WithSubclassId(byte subclassId);

    IItemBuilder WithMaterial(byte material);

    IItemBuilder WithInventoryType(sbyte inventoryType);

    IItemBuilder WithSheatheType(byte sheatheType);

    IItemBuilder WithSoundOverrideSubclassId(sbyte soundOverrideSubclassId);

    IItemBuilder WithIconFileDataId(int iconFileDataId);

    IItemBuilder WithItemGroupSoundsId(byte itemGroupSoundsId);

    IItemBuilder WithContentTuningId(int contentTuningId);

    IItemBuilder WithModifiedCraftingReagentItemId(int modifiedCraftingReagentItemId);

    IItemBuilder WithCraftingQualityId(int craftingQualityId);
}