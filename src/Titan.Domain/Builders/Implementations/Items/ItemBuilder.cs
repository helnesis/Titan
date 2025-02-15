using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Implementations.Items;

public sealed class ItemBuilder : IItemBuilder
{
    public Identifier Identifier { get; private set;}
    private byte _classId;
    private byte _subclassId;
    private byte _material;
    private sbyte _inventoryType;
    private byte _sheatheType;
    private sbyte _soundOverrideSubclassId;
    private int _iconFileDataId;
    private byte _itemGroupSoundsId;
    private int _contentTuningId;
    private int _modifiedCraftingReagentItemId;
    private int _craftingQualityId;

    public IItemBuilder WithIdentifier(Identifier identifier)
    {
        Identifier = identifier;
        return this;
    }

    public IItemBuilder WithClassId(byte classId)
    {
        _classId = classId;
        return this;
    }

    public IItemBuilder WithSubclassId(byte subclassId)
    {
        _subclassId = subclassId;
        return this;
    }

    public IItemBuilder WithMaterial(byte material)
    {
        _material = material;
        return this;
    }

    public IItemBuilder WithInventoryType(sbyte inventoryType)
    {
        _inventoryType = inventoryType;
        return this;
    }

    public IItemBuilder WithSheatheType(byte sheatheType)
    {
        _sheatheType = sheatheType;
        return this;
    }

    public IItemBuilder WithSoundOverrideSubclassId(sbyte soundOverrideSubclassId)
    {
        _soundOverrideSubclassId = soundOverrideSubclassId;
        return this;
    }

    public IItemBuilder WithIconFileDataId(int iconFileDataId)
    {
        _iconFileDataId = iconFileDataId;
        return this;
    }

    public IItemBuilder WithItemGroupSoundsId(byte itemGroupSoundsId)
    {
        _itemGroupSoundsId = itemGroupSoundsId;
        return this;
    }

    public IItemBuilder WithContentTuningId(int contentTuningId)
    {
        _contentTuningId = contentTuningId;
        return this;
    }

    public IItemBuilder WithModifiedCraftingReagentItemId(int modifiedCraftingReagentItemId)
    {
        _modifiedCraftingReagentItemId = modifiedCraftingReagentItemId;
        return this;
    }

    public IItemBuilder WithCraftingQualityId(int craftingQualityId)
    {
        _craftingQualityId = craftingQualityId;
        return this;
    }
    public Item Build()
    {
        return new Item(Identifier,
            _classId,
            _subclassId,
            _material,
            _inventoryType,
            _sheatheType,
            _soundOverrideSubclassId,
            _iconFileDataId,
            _itemGroupSoundsId,
            _contentTuningId,
            _modifiedCraftingReagentItemId,
            _craftingQualityId);
    }
}