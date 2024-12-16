using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateOutfits : Entity
{
    public uint Entry { get; init; }
    public uint NpcSoundsId { get; init; }
    public byte Race { get; init; }
    public byte Class { get; init; }
    public byte Gender { get; init; }
    public int SpellVisualKitId { get; init; }
    public string Customizations { get; init; }
    public long Head { get; init; }
    public long Shoulders { get; init; }
    public long Body { get; init; }
    public long Chest { get; init; }
    public long Waist { get; init; }
    public long Legs { get; init; }
    public long Feet { get; init; }
    public long Wrists { get; init; }
    public long Hands { get; init; }
    public long Back { get; init; }
    public long Tabard { get; init; }
    public ulong GuildId { get; init; }
    public string Description { get; init; }

    internal CreatureTemplateOutfits(
        Identifier identifier,
        uint entry,
        uint npcSoundsId,
        byte race,
        byte @class,
        byte gender,
        int spellVisualKitId,
        string customizations,
        long head,
        long shoulders,
        long body,
        long chest,
        long waist,
        long legs,
        long feet,
        long wrists,
        long hands,
        long back,
        long tabard,
        ulong guildId,
        string description
    ) : base(identifier) => (
        Entry,
        NpcSoundsId,
        Race,
        Class,
        Gender,
        SpellVisualKitId,
        Customizations,
        Head,
        Shoulders,
        Body,
        Chest,
        Waist,
        Legs,
        Feet,
        Wrists,
        Hands,
        Back,
        Tabard,
        GuildId,
        Description
    ) = (
        entry,
        npcSoundsId,
        race,
        @class,
        gender,
        spellVisualKitId,
        customizations,
        head,
        shoulders,
        body,
        chest,
        waist,
        legs,
        feet,
        wrists,
        hands,
        back,
        tabard,
        guildId,
        description
    );
}