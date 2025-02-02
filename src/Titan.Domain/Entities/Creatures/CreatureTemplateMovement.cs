using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateMovement : Entity
{
    [JsonPropertyName("hoverInitiallyEnabled")]
    public byte? HoverInitiallyEnabled { get; init; }
    
    [JsonPropertyName("chase")]
    public byte Chase { get; init; }
    
    [JsonPropertyName("random")]
    public byte Random { get; init; }
    
    [JsonPropertyName("interactionPauseTimer")]
    public uint? InteractionPauseTimer { get; init; }
    
    [JsonConstructor]
    internal CreatureTemplateMovement(Identifier identifier, byte? hoverInitiallyEnabled, byte chase, byte random, uint? interactionPauseTimer) : base(identifier)
        => (HoverInitiallyEnabled, Chase, Random, InteractionPauseTimer) = (hoverInitiallyEnabled, chase, random, interactionPauseTimer);

    public static ICreatureTemplateMovementBuilder Builder => new CreatureTemplateMovementBuilder();
}