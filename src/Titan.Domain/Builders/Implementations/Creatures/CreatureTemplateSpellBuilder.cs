using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;
using Titan.Domain.Entities.Creatures;

namespace Titan.Domain.Builders.Implementations.Creatures;

public sealed class CreatureTemplateSpellBuilder : ICreatureTemplateSpellBuilder
{
    private Identifier _creatureEntry;
    
    private byte _index;
    
    private Identifier _spellEntry;

    public CreatureTemplateSpell Build()
        => new(_creatureEntry, _index, _spellEntry);
    
    public ICreatureTemplateSpellBuilder WithCreatureEntry(Identifier creatureEntry)
    {
        _creatureEntry = creatureEntry;
        return this;
    }

    public ICreatureTemplateSpellBuilder WithIndex(byte index)
    {
        _index = index;
        return this;
    }

    public ICreatureTemplateSpellBuilder WithSpellEntry(Identifier spellEntry)
    {
        _spellEntry = spellEntry;
        return this;
    }
}