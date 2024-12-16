using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities;
using Titan.Domain.Enums;

namespace Titan.Domain.Builders.Implementations.Creatures;

public sealed class CreatureTemplateResistanceBuilder : ICreatureTemplateResistanceBuilder
{
    private Identifier _identifier;
    private SpellSchool _school;
    private short _resistance;

    public ICreatureTemplateResistanceBuilder WithIdentifier(Identifier identifier)
    {
        _identifier = identifier;
        return this;
    }

    public ICreatureTemplateResistanceBuilder WithSchool(SpellSchool school)
    {
        _school = school;
        return this;
    }

    public ICreatureTemplateResistanceBuilder WithResistance(short resistance)
    {
        _resistance = resistance;
        return this;
    }

    public CreatureTemplateResistance Build()
    {
        return new CreatureTemplateResistance(
            _identifier,
            _school,
            _resistance
        );
    }
}