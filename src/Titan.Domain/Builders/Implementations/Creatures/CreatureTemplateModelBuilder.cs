using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities;

namespace Titan.Domain.Builders.Implementations.Creatures;

public class CreatureTemplateModelBuilder : ICreatureTemplateModelBuilder
{
    private Identifier _identifier;
    private uint _index;
    private uint _displayId;
    private float _displayScale;
    private float _probability;

    public ICreatureTemplateModelBuilder WithIdentifier(Identifier identifier)
    {
        _identifier = identifier;
        return this;
    }

    public ICreatureTemplateModelBuilder WithIndex(uint index)
    {
        _index = index;
        return this;
    }

    public ICreatureTemplateModelBuilder WithDisplayId(uint displayId)
    {
        _displayId = displayId;
        return this;
    }

    public ICreatureTemplateModelBuilder WithDisplayScale(float displayScale)
    {
        _displayScale = displayScale;
        return this;
    }

    public ICreatureTemplateModelBuilder WithProbability(float probability)
    {
        _probability = probability;
        return this;
    }

    public CreatureTemplateModel Build()
    {
        return new CreatureTemplateModel(
            _identifier,
            _index,
            _displayId,
            _displayScale,
            _probability
        );
    }
}