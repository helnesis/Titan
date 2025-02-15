using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Enums;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateFlags
{
    [JsonPropertyName("extraFlags")]
    public CreatureExtraFlags ExtraFlags { get; init; }

    [JsonPropertyName("creatureFlags")]
    public CreatureFlags CreatureFlags { get; init; }

    [JsonPropertyName("unitFlags")]
    public CreatureUnitFlags UnitFlags { get; init; }

    [JsonPropertyName("unitFlags2")]
    public CreatureUnitFlags2 UnitFlags2 { get; init; }

    [JsonPropertyName("unitFlags3")]
    public CreatureUnitFlags3 UnitFlags3 { get; init; }


    [JsonConstructor]
    internal CreatureTemplateFlags(CreatureExtraFlags extraFlags, CreatureFlags flags, CreatureUnitFlags unitFlags,
        CreatureUnitFlags2 unitFlags2, CreatureUnitFlags3 unitFlags3)
        => (ExtraFlags, CreatureFlags, UnitFlags, UnitFlags2, UnitFlags3) =
            (extraFlags, flags, unitFlags, unitFlags2, unitFlags3);
    
    public static ICreatureTemplateFlagsBuilder Builder => new CreatureTemplateFlagsBuilder();
}
