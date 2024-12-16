using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateModel : Entity
{
    public uint Index { get; init; }
    public uint DisplayId { get; init; }
    public float DisplayScale { get; init; }
    public float Probability { get; init; }

    internal CreatureTemplateModel(Identifier identifier, uint idx, uint displayId, float displayScale, float probability) : base(identifier)
        => (Index, DisplayId, DisplayScale, Probability) = (idx, displayId, displayScale, probability);
}