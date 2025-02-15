using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Enums;

namespace Titan.Domain.Builders.Implementations.Creatures;

public class CreatureTemplateFlagsBuilder : ICreatureTemplateFlagsBuilder
{
    private CreatureExtraFlags _extraFlags;
    private CreatureFlags _creatureFlags;
    private CreatureUnitFlags _unitFlags;
    private CreatureUnitFlags2 _unitFlags2;
    private CreatureUnitFlags3 _unitFlags3;

    public ICreatureTemplateFlagsBuilder WithExtraFlags(CreatureExtraFlags extraFlags)
    {
        _extraFlags = extraFlags;
        return this;
    }

    public ICreatureTemplateFlagsBuilder WithCreatureFlags(CreatureFlags creatureFlags)
    {
        _creatureFlags = creatureFlags;
        return this;
    }

    public ICreatureTemplateFlagsBuilder WithUnitFlags(CreatureUnitFlags unitFlags)
    {
        _unitFlags = unitFlags;
        return this;
    }

    public ICreatureTemplateFlagsBuilder WithUnitFlags2(CreatureUnitFlags2 unitFlags2)
    {
        _unitFlags2 = unitFlags2;
        return this;
    }

    public ICreatureTemplateFlagsBuilder WithUnitFlags3(CreatureUnitFlags3 unitFlags3)
    {
        _unitFlags3 = unitFlags3;
        return this;
    }

    public Identifier Identifier { get; } = Identifier.Empty;
    public CreatureTemplateFlags Build()
    {
        return new CreatureTemplateFlags(_extraFlags, _creatureFlags, _unitFlags, _unitFlags2, _unitFlags3);
    }
}