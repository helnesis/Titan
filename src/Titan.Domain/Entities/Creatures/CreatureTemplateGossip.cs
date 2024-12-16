using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateGossip : Entity
{
    public uint MenuId { get; init; }
    internal CreatureTemplateGossip(Identifier identifier, uint menuId) : base(identifier)
        => MenuId = menuId;
}