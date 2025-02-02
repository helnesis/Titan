using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateOutfits : Entity
{
     [JsonPropertyName("entry")]
    public uint Entry { get; init; }

    [JsonPropertyName("npcSoundsId")]
    public uint NpcSoundsId { get; init; }

    [JsonPropertyName("race")]
    public byte Race { get; init; }

    [JsonPropertyName("classType")]
    public byte Class { get; init; }

    [JsonPropertyName("gender")]
    public byte Gender { get; init; }

    [JsonPropertyName("spellVisualKitId")]
    public int SpellVisualKitId { get; init; }

    [JsonPropertyName("customizations")]
    public string Customizations { get; init; }

    [JsonPropertyName("head")]
    public long Head { get; init; }

    [JsonPropertyName("shoulders")]
    public long Shoulders { get; init; }

    [JsonPropertyName("body")]
    public long Body { get; init; }

    [JsonPropertyName("chest")]
    public long Chest { get; init; }

    [JsonPropertyName("waist")]
    public long Waist { get; init; }

    [JsonPropertyName("legs")]
    public long Legs { get; init; }

    [JsonPropertyName("feet")]
    public long Feet { get; init; }

    [JsonPropertyName("wrists")]
    public long Wrists { get; init; }

    [JsonPropertyName("hands")]
    public long Hands { get; init; }

    [JsonPropertyName("back")]
    public long Back { get; init; }

    [JsonPropertyName("tabard")]
    public long Tabard { get; init; }

    [JsonPropertyName("headAppearance")]
    public uint HeadAppearance { get; init; }

    [JsonPropertyName("shouldersAppearance")]
    public uint ShouldersAppearance { get; init; }

    [JsonPropertyName("bodyAppearance")]
    public uint BodyAppearance { get; init; }

    [JsonPropertyName("chestAppearance")]
    public uint ChestAppearance { get; init; }

    [JsonPropertyName("waistAppearance")]
    public uint WaistAppearance { get; init; }

    [JsonPropertyName("legsAppearance")]
    public uint LegsAppearance { get; init; }

    [JsonPropertyName("feetAppearance")]
    public uint FeetAppearance { get; init; }

    [JsonPropertyName("wristsAppearance")]
    public uint WristsAppearance { get; init; }

    [JsonPropertyName("handsAppearance")]
    public uint HandsAppearance { get; init; }

    [JsonPropertyName("backAppearance")]
    public uint BackAppearance { get; init; }

    [JsonPropertyName("tabardAppearance")]
    public uint TabardAppearance { get; init; }

    [JsonPropertyName("guildId")]
    public ulong GuildId { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }
    
    [JsonConstructor]
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