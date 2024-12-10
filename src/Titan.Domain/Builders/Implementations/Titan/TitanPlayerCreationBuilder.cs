using Titan.Domain.Builders.Interfaces.Titan;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Titan;

namespace Titan.Domain.Builders.Implementations.Titan;

public sealed class TitanPlayerCreationBuilder : ITitanPlayerCreationBuilder
{
    private Identifier _identifier;
    
    private Identifier _creationIdentifier;
    
    private CreationType _creationType;
    public TitanPlayerCreation Build()
        => new(_identifier, _creationIdentifier, _creationType);
    public ITitanPlayerCreationBuilder WithCreationIdentifier(Identifier creationIdentifier)
    {
        _creationIdentifier = creationIdentifier;
        return this;
    }

    public ITitanPlayerCreationBuilder WithCreationType(CreationType creationType)
    {
        _creationType = creationType;
        return this;
    }

    public ITitanPlayerCreationBuilder WithIdentifier(Identifier identifier)
    {
        _identifier = identifier;
        return this;
    }
}