using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateAddon : Entity
{
    public uint PathId { get; init; }
    public uint Mount { get; init; }
    public uint MountCreatureId { get; init; }
    public byte StandState { get; init; }
    public byte AnimTier { get; init; }

    //@TODO: Replace me with a proper enum
    public byte VisibilityFlags { get; init; }
    public byte SheathState { get; init; }

    //@TODO: Replace me with a proper enum
    public byte PvPFlags { get; init; }
    public uint Emote { get; init; }
    public short AiAnimKit { get; init; }
    public short MovementAnimKit { get; init; }
    public short MeleeAnimKit { get; init; }
    public byte VisibilityDistanceType { get; init; }
    public string Auras { get; init; }

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
}