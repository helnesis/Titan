using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateMovement : Entity
{
    public byte HoverInitiallyEnabled { get; init; }
    public byte Chase { get; init; }
    public byte Random { get; init; }
    public uint InteractionPauseTimer { get; init; }
    internal CreatureTemplateMovement(Identifier identifier, byte hoverInitiallyEnabled, byte chase, byte random, uint interactionPauseTimer) : base(identifier)
        => (HoverInitiallyEnabled, Chase, Random, InteractionPauseTimer) = (hoverInitiallyEnabled, chase, random, interactionPauseTimer);
}