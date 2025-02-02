using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateAddon : Entity
{
    [JsonPropertyName("pathId")]
    public uint PathId { get; init; }

    [JsonPropertyName("mount")]
    public uint Mount { get; init; }

    [JsonPropertyName("mountCreatureId")]
    public uint MountCreatureId { get; init; }

    [JsonPropertyName("standState")]
    public byte StandState { get; init; }

    [JsonPropertyName("animTier")]
    public byte AnimTier { get; init; }

    [JsonPropertyName("visibilityFlags")]
    public byte VisibilityFlags { get; init; }

    [JsonPropertyName("sheathState")]
    public byte SheathState { get; init; }

    [JsonPropertyName("pvpFlags")]
    public byte PvPFlags { get; init; }

    [JsonPropertyName("emote")]
    public uint Emote { get; init; }

    [JsonPropertyName("aiAnimKit")]
    public short AiAnimKit { get; init; }

    [JsonPropertyName("movementAnimKit")]
    public short MovementAnimKit { get; init; }

    [JsonPropertyName("meleeAnimKit")]
    public short MeleeAnimKit { get; init; }

    [JsonPropertyName("visibilityDistanceType")]
    public byte VisibilityDistanceType { get; init; }

    [JsonPropertyName("auras")]
    public string Auras { get; init; }

    [JsonConstructor]
    internal CreatureTemplateAddon(
        Identifier identifier,
        uint pathId,
        uint mount,
        uint mountCreatureId,
        byte standState,
        byte animTier,
        byte visibilityFlags,
        byte sheathState,
        byte pvpFlags,
        uint emote,
        short aiAnimKit,
        short movementAnimKit,
        short meleeAnimKit,
        byte visibilityDistanceType,
        string auras
    ) : base(identifier) => (
        PathId,
        Mount,
        MountCreatureId,
        StandState,
        AnimTier,
        VisibilityFlags,
        SheathState,
        PvPFlags,
        Emote,
        AiAnimKit,
        MovementAnimKit,
        MeleeAnimKit,
        VisibilityDistanceType,
        Auras
    ) = (
        pathId,
        mount,
        mountCreatureId,
        standState,
        animTier,
        visibilityFlags,
        sheathState,
        pvpFlags,
        emote,
        aiAnimKit,
        movementAnimKit,
        meleeAnimKit,
        visibilityDistanceType,
        auras
    );

    public static ICreatureTemplateAddonBuilder Builder => new CreatureTemplateAddonBuilder();
}