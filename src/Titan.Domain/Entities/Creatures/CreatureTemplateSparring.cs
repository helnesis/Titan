using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateSparring : Entity
{
    public float NoNpcDamageBelowHealthPct { get; init; }
    internal CreatureTemplateSparring(Identifier identifier, float noNpcDamageBelowHealthPct)
        => (Identifier, NoNpcDamageBelowHealthPct) = (identifier, noNpcDamageBelowHealthPct);
    
    public static ICreatureTemplateSparringBuilder Builder => new CreatureTemplateSparringBuilder();
}