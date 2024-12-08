using Titan.Domain.Builders.Base;
using Titan.Domain.Entities.Base;
using Titan.Domain.Entities.Creatures;

namespace Titan.Domain.Builders.Interfaces.Creatures;

public interface ICreatureTemplateSparringBuilder : IBuilder<CreatureTemplateSparring>
{
    ICreatureTemplateSparringBuilder WithCreatureEntry(Identifier creatureEntry);
    
    ICreatureTemplateSparringBuilder WithNoNpcDamageBelowHealthPct(float noNpcDamageBelowHealthPct);
}