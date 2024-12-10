using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Titan;

namespace Titan.Domain.Builders.Interfaces.Titan
{
    public interface ITitanCreaturePresetBuilder : IBuilder<TitanCreaturePreset>
    {
        ITitanCreaturePresetBuilder WithIdentifier(Identifier identifier);
        ITitanCreaturePresetBuilder WithPresetName(string presetName);
        ITitanCreaturePresetBuilder WithPresetData(string rawData);
    }
}
