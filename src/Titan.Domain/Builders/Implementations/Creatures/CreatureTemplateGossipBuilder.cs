using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;

namespace Titan.Domain.Builders.Implementations.Creatures;

public sealed class CreatureTemplateGossipBuilder : ICreatureTemplateGossipBuilder
{
    private Identifier _identifier;
    private uint _menuId;
    public CreatureTemplateGossip Build()
        => new(_identifier, _menuId);
    public ICreatureTemplateGossipBuilder WithIdentifier(Identifier identifier)
    {
        _identifier = identifier;
        return this;
    }

    public ICreatureTemplateGossipBuilder WithMenuId(uint menuId)
    {
        _menuId = menuId;
        return this;
    }
}