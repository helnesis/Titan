using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateSpell
{
    /// <summary>
    /// The creature's entry.
    /// </summary>
    public Identifier CreatureEntry { get; init; }
    
    /// <summary>
    /// Spell index, related to the creature's spell bar.
    /// </summary>
    public byte Index { get; init; }
    
    /// <summary>
    /// The spell entry.
    /// </summary>
    public Identifier SpellEntry { get; init; }
    
    /// <summary>
    /// Initialize a new instance of <see cref="CreatureTemplateSpell"/>.
    /// </summary>
    /// <param name="creatureEntry">Creature entry</param>
    /// <param name="index">Spell index</param>
    /// <param name="spellEntry">Spell entry</param>
    internal CreatureTemplateSpell(Identifier creatureEntry, byte index, Identifier spellEntry) => 
        (CreatureEntry, Index, SpellEntry) = (creatureEntry, index, spellEntry);

    public static ICreatureTemplateSpellBuilder Builder => new CreatureTemplateSpellBuilder();
}