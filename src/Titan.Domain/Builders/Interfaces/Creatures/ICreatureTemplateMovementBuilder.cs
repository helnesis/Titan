using Titan.Domain.Builders.Base;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities;

namespace Titan.Domain.Builders.Interfaces.Creatures;

public interface ICreatureTemplateMovementBuilder : IBuilder<CreatureTemplateMovement>
{
    ICreatureTemplateMovementBuilder WithIdentifier(Identifier identifier);
    ICreatureTemplateMovementBuilder WithHoverInitiallyEnabled(byte hoverInitiallyEnabled);
    ICreatureTemplateMovementBuilder WithChase(byte chase);
    ICreatureTemplateMovementBuilder WithRandom(byte random);
    ICreatureTemplateMovementBuilder WithInteractionPauseTimer(uint interactionPauseTimer);
}