using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Interfaces.Items;

public interface IItemModifiedAppearanceExtraBuilder : IBuilder<ItemModifiedAppearanceExtra>
{
    IItemModifiedAppearanceExtraBuilder WithIdentifier(Identifier identifier);

    IItemModifiedAppearanceExtraBuilder WithIconFileDataId(int iconFileDataId);

    IItemModifiedAppearanceExtraBuilder WithUnequippedIconFileDataId(int unequippedIconFileDataId);

    IItemModifiedAppearanceExtraBuilder WithSheatheType(byte sheatheType);

    IItemModifiedAppearanceExtraBuilder WithDisplayWeaponSubclassId(sbyte displayWeaponSubclassId);

    IItemModifiedAppearanceExtraBuilder WithDisplayInventoryType(sbyte displayInventoryType);
}