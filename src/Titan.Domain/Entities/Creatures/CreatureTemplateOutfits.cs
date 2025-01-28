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
    public uint HeadAppearance { get; init; }
    public uint ShouldersAppearance { get; init; }
    public uint BodyAppearance { get; init; }
    public uint ChestAppearance { get; init; }
    public uint WaistAppearance { get; init; }
    public uint LegsAppearance { get; init; }
    public uint FeetAppearance { get; init; }
    public uint WristsAppearance { get; init; }
    public uint HandsAppearance { get; init; }
    public uint BackAppearance { get; init; }
    public uint TabardAppearance { get; init; }
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
        uint headAppearance,
        uint shouldersAppearance,
        uint bodyAppearance,
        uint chestAppearance,
        uint waistAppearance,
        uint legsAppearance,
        uint feetAppearance,
        uint wristsAppearance,
        uint handsAppearance,
        uint backAppearance,
        uint tabardAppearance,
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