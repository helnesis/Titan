using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Implementations.Items;

public sealed class ItemModifiedAppearanceBuilder : IItemModifiedAppearanceBuilder
{
    public Identifier Identifier { get; private set;}
    private int _itemId;
    private int _itemAppearanceModifierId;
    private int _itemAppearanceId;
    private int _orderIndex;
    private byte _transmogSourceTypeEnum;
    private int _flags;

    public IItemModifiedAppearanceBuilder WithIdentifier(Identifier identifier)
    {
        Identifier = identifier;
        return this;
    }

    public IItemModifiedAppearanceBuilder WithItemId(int itemId)
    {
        _itemId = itemId;
        return this;
    }

    public IItemModifiedAppearanceBuilder WithItemAppearanceModifierId(int itemAppearanceModifierId)
    {
        _itemAppearanceModifierId = itemAppearanceModifierId;
        return this;
    }

    public IItemModifiedAppearanceBuilder WithItemAppearanceId(int itemAppearanceId)
    {
        _itemAppearanceId = itemAppearanceId;
        return this;
    }

    public IItemModifiedAppearanceBuilder WithOrderIndex(int orderIndex)
    {
        _orderIndex = orderIndex;
        return this;
    }

    public IItemModifiedAppearanceBuilder WithTransmogSourceTypeEnum(byte transmogSourceTypeEnum)
    {
        _transmogSourceTypeEnum = transmogSourceTypeEnum;
        return this;
    }

    public IItemModifiedAppearanceBuilder WithFlags(int flags)
    {
        _flags = flags;
        return this;
    }
    public ItemModifiedAppearance Build()
    {
        return new ItemModifiedAppearance(Identifier,
            _itemId,
            _itemAppearanceModifierId,
            _itemAppearanceId,
            _orderIndex,
            _transmogSourceTypeEnum,
            _flags);
    }
}