using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;

namespace Titan.Domain.Builders.Interfaces.Creatures;

public interface ICreatureTemplateGossipBuilder : IBuilder<CreatureTemplateGossip>
{
    ICreatureTemplateGossipBuilder WithIdentifier(Identifier identifier);
    ICreatureTemplateGossipBuilder WithMenuId(uint menuId);
}