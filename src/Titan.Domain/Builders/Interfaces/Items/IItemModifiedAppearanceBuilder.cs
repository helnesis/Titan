using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Interfaces.Items;

public interface IItemModifiedAppearanceBuilder : IBuilder<ItemModifiedAppearance>
{
    IItemModifiedAppearanceBuilder WithIdentifier(Identifier identifier);

    IItemModifiedAppearanceBuilder WithItemId(int itemId);

    IItemModifiedAppearanceBuilder WithItemAppearanceModifierId(int itemAppearanceModifierId);

    IItemModifiedAppearanceBuilder WithItemAppearanceId(int itemAppearanceId);

    IItemModifiedAppearanceBuilder WithOrderIndex(int orderIndex);

    IItemModifiedAppearanceBuilder WithTransmogSourceTypeEnum(byte transmogSourceTypeEnum);

    IItemModifiedAppearanceBuilder WithFlags(int flags);
}