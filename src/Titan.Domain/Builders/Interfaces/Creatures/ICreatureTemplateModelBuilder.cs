using Titan.Domain.Builders.Base;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities;

namespace Titan.Domain.Builders.Interfaces.Creatures;

public interface ICreatureTemplateModelBuilder : IBuilder<CreatureTemplateModel>
{
    ICreatureTemplateModelBuilder WithIdentifier(Identifier identifier);
    ICreatureTemplateModelBuilder WithIndex(uint index);
    ICreatureTemplateModelBuilder WithDisplayId(uint displayId);
    ICreatureTemplateModelBuilder WithDisplayScale(float displayScale);
    ICreatureTemplateModelBuilder WithProbability(float probability);
}