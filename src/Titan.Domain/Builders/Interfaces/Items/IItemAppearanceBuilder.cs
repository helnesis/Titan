using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Interfaces.Items;

public interface IItemAppearanceBuilder : IBuilder<ItemAppearance>
{
    IItemAppearanceBuilder WithIdentifier(Identifier identifier);

    IItemAppearanceBuilder WithDisplayType(int displayType);

    IItemAppearanceBuilder WithItemDisplayInfoId(int itemDisplayInfoId);

    IItemAppearanceBuilder WithDefaultIconFileDataId(int defaultIconFileDataId);

    IItemAppearanceBuilder WithUiOrder(int uiOrder);

    IItemAppearanceBuilder WithPlayerConditionId(int playerConditionId);
}