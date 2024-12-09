using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateSparring
{
    /// <summary>
    /// The creature entry.
    /// </summary>
    public Identifier CreatureEntry { get; init; }

    /// <summary>
    /// The percentage of health below which the creature will not take damage from NPCs.
    /// </summary>
    public float NoNpcDamageBelowHealthPct { get; init; }

    internal CreatureTemplateSparring(Identifier identifier, float noNpcDamageBelowHealthPct)
        => (CreatureEntry, NoNpcDamageBelowHealthPct) = (identifier, noNpcDamageBelowHealthPct);

    /// <summary>
    /// Creature template sparring builder.
    /// </summary>
    public static ICreatureTemplateSparringBuilder Builder => new CreatureTemplateSparringBuilder();
}