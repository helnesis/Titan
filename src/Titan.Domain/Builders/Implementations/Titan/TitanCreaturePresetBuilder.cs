using System.Buffers.Text;
using System.Text;
using Titan.Domain.Builders.Interfaces.Titan;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Titan;

namespace Titan.Domain.Builders.Implementations.Titan;

public sealed class TitanCreaturePresetBuilder : ITitanCreaturePresetBuilder
{
    private Identifier _identifier;
    
    private string _presetName;

    private string _presetData;
    public TitanCreaturePreset Build()
        => new(_identifier, _presetName, _presetData);

    public ITitanCreaturePresetBuilder WithIdentifier(Identifier identifier)
    {
        _identifier = identifier;
        return this;
    }

    public ITitanCreaturePresetBuilder WithPresetData(string rawData)
    {
        _presetData = Convert.ToBase64String(Encoding.UTF8.GetBytes(rawData));
        return this;
    }

    public ITitanCreaturePresetBuilder WithPresetName(string presetName)
    {
        _presetName = presetName;
        return this;
    }
}