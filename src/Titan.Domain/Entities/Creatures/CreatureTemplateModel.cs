using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateModel : Entity
{
    [JsonPropertyName("index")]
    public uint Index { get; init; }
    
    [JsonPropertyName("displayId")]
    public uint DisplayId { get; init; }
    
    [JsonPropertyName("displayScale")]
    public float DisplayScale { get; init; }
    
    [JsonPropertyName("probability")]
    public float Probability { get; init; }
    
    [JsonConstructor]
    internal CreatureTemplateModel(Identifier identifier, uint index, uint displayId, float displayScale, float probability) : base(identifier)
        => (Index, DisplayId, DisplayScale, Probability) = (index, displayId, displayScale, probability);
    
    public static ICreatureTemplateModelBuilder Builder => new CreatureTemplateModelBuilder();
}