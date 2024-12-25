using Titan.Domain.Builders.Base;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Enums;

namespace Titan.Domain.Builders.Interfaces.Creatures;

public interface ICreatureTemplateFlagsBuilder : IBuilder<CreatureTemplateFlags>
{
    ICreatureTemplateFlagsBuilder WithExtraFlags(CreatureExtraFlags extraFlags);
    
    ICreatureTemplateFlagsBuilder WithCreatureFlags(CreatureFlags creatureFlags);
    
    ICreatureTemplateFlagsBuilder WithUnitFlags(CreatureUnitFlags unitFlags);
    
    ICreatureTemplateFlagsBuilder WithUnitFlags2(CreatureUnitFlags2 unitFlags2);
    
    ICreatureTemplateFlagsBuilder WithUnitFlags3(CreatureUnitFlags3 unitFlags3);
}