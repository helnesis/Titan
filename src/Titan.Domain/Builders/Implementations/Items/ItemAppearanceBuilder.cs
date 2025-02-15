using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Implementations.Items;

public sealed class ItemAppearanceBuilder : IItemAppearanceBuilder
{
    public Identifier Identifier { get; private set;}
    private int _displayType;
    private int _itemDisplayInfoId;
    private int _defaultIconFileDataId;
    private int _uiOrder;
    private int _playerConditionId;

    public IItemAppearanceBuilder WithIdentifier(Identifier identifier)
    {
        Identifier = identifier;
        return this;
    }

    
    public IItemAppearanceBuilder WithDisplayType(int displayType)
    {
        _displayType = displayType;
        return this;
    }

    public IItemAppearanceBuilder WithItemDisplayInfoId(int itemDisplayInfoId)
    {
        _itemDisplayInfoId = itemDisplayInfoId;
        return this;
    }

    public IItemAppearanceBuilder WithDefaultIconFileDataId(int defaultIconFileDataId)
    {
        _defaultIconFileDataId = defaultIconFileDataId;
        return this;
    }

    public IItemAppearanceBuilder WithUiOrder(int uiOrder)
    {
        _uiOrder = uiOrder;
        return this;
    }

    public IItemAppearanceBuilder WithPlayerConditionId(int playerConditionId)
    {
        _playerConditionId = playerConditionId;
        return this;
    }
    public ItemAppearance Build()
    {
        return new ItemAppearance(Identifier,
            _displayType,
            _itemDisplayInfoId,
            _defaultIconFileDataId,
            _uiOrder,
            _playerConditionId);
    }
}