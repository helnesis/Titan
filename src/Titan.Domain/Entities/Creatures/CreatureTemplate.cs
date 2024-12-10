using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplate : Entity
{
    internal CreatureTemplate(Identifier identifier) : base(identifier) { }
}