using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateGossip : Entity
{
    public uint MenuId { get; init; }
    internal CreatureTemplateGossip(Identifier identifier, uint menuId) : base(identifier)
        => MenuId = menuId;
    
    public static ICreatureTemplateGossipBuilder Builder => new CreatureTemplateGossipBuilder();
}