using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Implementations.Items;

public sealed class ItemModifiedAppearanceExtraBuilder : IItemModifiedAppearanceExtraBuilder
{
    public Identifier Identifier { get; private set;}
    private int _iconFileDataId;
    private int _unequippedIconFileDataId;
    private byte _sheatheType;
    private sbyte _displayWeaponSubclassId;
    private sbyte _displayInventoryType;

    public IItemModifiedAppearanceExtraBuilder WithIdentifier(Identifier identifier)
    {
        Identifier = identifier;
        return this;
    }

    public IItemModifiedAppearanceExtraBuilder WithIconFileDataId(int iconFileDataId)
    {
        _iconFileDataId = iconFileDataId;
        return this;
    }

    public IItemModifiedAppearanceExtraBuilder WithUnequippedIconFileDataId(int unequippedIconFileDataId)
    {
        _unequippedIconFileDataId = unequippedIconFileDataId;
        return this;
    }

    public IItemModifiedAppearanceExtraBuilder WithSheatheType(byte sheatheType)
    {
        _sheatheType = sheatheType;
        return this;
    }

    public IItemModifiedAppearanceExtraBuilder WithDisplayWeaponSubclassId(sbyte displayWeaponSubclassId)
    {
        _displayWeaponSubclassId = displayWeaponSubclassId;
        return this;
    }

    public IItemModifiedAppearanceExtraBuilder WithDisplayInventoryType(sbyte displayInventoryType)
    {
        _displayInventoryType = displayInventoryType;
        return this;
    }
    public ItemModifiedAppearanceExtra Build()
    {
        return new ItemModifiedAppearanceExtra(Identifier,
            _iconFileDataId,
            _unequippedIconFileDataId,
            _sheatheType,
            _displayWeaponSubclassId,
            _displayInventoryType);
    }
}