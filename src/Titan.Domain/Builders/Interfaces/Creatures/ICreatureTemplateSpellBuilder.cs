using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;

namespace Titan.Domain.Builders.Interfaces.Creatures;

public interface ICreatureTemplateSpellBuilder : IBuilder<CreatureTemplateSpell>
{
    ICreatureTemplateSpellBuilder WithCreatureEntry(Identifier creatureEntry);

    ICreatureTemplateSpellBuilder WithIndex(byte index);
    
    ICreatureTemplateSpellBuilder WithSpellEntry(Identifier spellEntry);
}