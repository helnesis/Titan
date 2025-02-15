using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;

namespace Titan.Domain.Builders.Interfaces.Items;

public interface IItemNameDescriptionBuilder : IBuilder<ItemNameDescription>
{
    IItemNameDescriptionBuilder WithIdentifier(Identifier identifier);

    IItemNameDescriptionBuilder WithDescription(string? description);

    IItemNameDescriptionBuilder WithColor(int color);
}