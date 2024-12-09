using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;
using Titan.Domain.Entities.Creatures;

namespace Titan.Domain.Builders.Implementations.Creatures;

public sealed class CreatureTemplateSparringBuilder : ICreatureTemplateSparringBuilder
{
    private Identifier _creatureEntry;
    private float _noNpcDamageBelowHealthPct;

    public CreatureTemplateSparring Build()
        => new(_creatureEntry, _noNpcDamageBelowHealthPct);

    public ICreatureTemplateSparringBuilder WithCreatureEntry(Identifier creatureEntry)
    {
        _creatureEntry = creatureEntry;
        return this;
    }

    public ICreatureTemplateSparringBuilder WithNoNpcDamageBelowHealthPct(float noNpcDamageBelowHealthPct)
    {
        _noNpcDamageBelowHealthPct = noNpcDamageBelowHealthPct;
        return this;
    }
}