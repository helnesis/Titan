using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Titan;

namespace Titan.Domain.Builders.Interfaces.Titan;

public interface ITitanPlayerCreationBuilder : IBuilder<TitanPlayerCreation>
{
    ITitanPlayerCreationBuilder WithIdentifier(Identifier identifier);
    ITitanPlayerCreationBuilder WithCreationIdentifier(Identifier creationIdentifier);
    ITitanPlayerCreationBuilder WithCreationType(CreationType creationType);
}
