using Titan.Domain.Builders.Implementations.Titan;
using Titan.Domain.Builders.Interfaces.Titan;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Titan;

public sealed record TitanCreaturePreset : Entity
{
    /// <summary>
    /// Preset's name.
    /// </summary>
    public string PresetName { get; init; }

    /// <summary>
    /// Preset data, in base64 format.
    /// </summary>
    public string Preset { get; init; }

    internal TitanCreaturePreset(Identifier identifier, string presetName, string preset) : base(identifier)
        => (PresetName, Preset) = (presetName, preset);

    public static ITitanCreaturePresetBuilder Builder => new TitanCreaturePresetBuilder();
}