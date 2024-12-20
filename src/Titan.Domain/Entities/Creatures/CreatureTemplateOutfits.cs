using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
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
    public uint Head { get; init; }
    public uint Shoulders { get; init; }
    public uint Body { get; init; }
    public uint Chest { get; init; }
    public uint Waist { get; init; }
    public uint Legs { get; init; }
    public uint Feet { get; init; }
    public uint Wrists { get; init; }
    public uint Hands { get; init; }
    public uint Back { get; init; }
    public uint Tabard { get; init; }
    public long HeadAppearance { get; init; }
    public long ShouldersAppearance { get; init; }
    public long BodyAppearance { get; init; }
    public long ChestAppearance { get; init; }
    public long WaistAppearance { get; init; }
    public long LegsAppearance { get; init; }
    public long FeetAppearance { get; init; }
    public long WristsAppearance { get; init; }
    public long HandsAppearance { get; init; }
    public long BackAppearance { get; init; }
    public long TabardAppearance { get; init; }
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
        uint head,
        uint shoulders,
        uint body,
        uint chest,
        uint waist,
        uint legs,
        uint feet,
        uint wrists,
        uint hands,
        uint back,
        uint tabard,
        long headAppearance,
        long shouldersAppearance,
        long bodyAppearance,
        long chestAppearance,
        long waistAppearance,
        long legsAppearance,
        long feetAppearance,
        long wristsAppearance,
        long handsAppearance,
        long backAppearance,
        long tabardAppearance,
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
        HeadAppearance,
        ShouldersAppearance,
        BodyAppearance,
        ChestAppearance,
        WaistAppearance,
        LegsAppearance,
        FeetAppearance,
        WristsAppearance,
        HandsAppearance,
        BackAppearance,
        TabardAppearance,
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
        headAppearance,
        shouldersAppearance,
        bodyAppearance,
        chestAppearance,
        waistAppearance,
        legsAppearance,
        feetAppearance,
        wristsAppearance,
        handsAppearance,
        backAppearance,
        tabardAppearance,
        guildId,
        description
    );

    public static ICreatureTemplateOutfitsBuilder Builder => new CreatureTemplateOutfitsBuilder();
}