using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities;

namespace Titan.Domain.Builders.Implementations.Creatures;

public sealed class CreatureTemplateMovementBuilder : ICreatureTemplateMovementBuilder
{
    private Identifier _identifier;
    private byte _hoverInitiallyEnabled;
    private byte _chase;
    private byte _random;
    private uint _interactionPauseTimer;

    public ICreatureTemplateMovementBuilder WithIdentifier(Identifier identifier)
    {
        _identifier = identifier;
        return this;
    }

    public ICreatureTemplateMovementBuilder WithHoverInitiallyEnabled(byte hoverInitiallyEnabled)
    {
        _hoverInitiallyEnabled = hoverInitiallyEnabled;
        return this;
    }

    public ICreatureTemplateMovementBuilder WithChase(byte chase)
    {
        _chase = chase;
        return this;
    }

    public ICreatureTemplateMovementBuilder WithRandom(byte random)
    {
        _random = random;
        return this;
    }

    public ICreatureTemplateMovementBuilder WithInteractionPauseTimer(uint interactionPauseTimer)
    {
        _interactionPauseTimer = interactionPauseTimer;
        return this;
    }

    public CreatureTemplateMovement Build()
    {
        return new CreatureTemplateMovement(
            _identifier,
            _hoverInitiallyEnabled,
            _chase,
            _random,
            _interactionPauseTimer
        );
    }
}