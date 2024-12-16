using Titan.Domain.Builders.Base;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities;
using Titan.Domain.Enums;

namespace Titan.Domain.Builders.Interfaces.Creatures;

public interface ICreatureTemplateResistanceBuilder : IBuilder<CreatureTemplateResistance>
{
    ICreatureTemplateResistanceBuilder WithIdentifier(Identifier identifier);
    ICreatureTemplateResistanceBuilder WithSchool(SpellSchool school);
    ICreatureTemplateResistanceBuilder WithResistance(short resistance);
}