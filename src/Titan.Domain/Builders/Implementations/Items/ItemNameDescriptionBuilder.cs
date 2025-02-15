using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Implementations.Items;

public sealed class ItemNameDescriptionBuilder : IItemNameDescriptionBuilder
{
    public Identifier Identifier { get; private set;}
    private string? _description;
    private int _color;

    public IItemNameDescriptionBuilder WithIdentifier(Identifier identifier)
    {
        Identifier = identifier;
        return this;
    }

    public IItemNameDescriptionBuilder WithDescription(string? description)
    {
        _description = description;
        return this;
    }

    public IItemNameDescriptionBuilder WithColor(int color)
    {
        _color = color;
        return this;
    }
    public ItemNameDescription Build()
    {
        return new ItemNameDescription(Identifier,
            _description,
            _color);
    }
}