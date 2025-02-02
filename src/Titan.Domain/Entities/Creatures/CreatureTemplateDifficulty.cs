using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateDifficulty : Entity
{
    [JsonPropertyName("difficultyId")]
    public byte DifficultyId { get; init; }

    [JsonPropertyName("levelScalingDeltaMin")]
    public short LevelScalingDeltaMin { get; init; }

    [JsonPropertyName("levelScalingDeltaMax")]
    public short LevelScalingDeltaMax { get; init; }

    [JsonPropertyName("contentTuningId")]
    public int ContentTuningId { get; init; }

    [JsonPropertyName("healthScalingExpansion")]
    public int HealthScalingExpansion { get; init; }

    [JsonPropertyName("healthModifier")]
    public float HealthModifier { get; init; }

    [JsonPropertyName("manaModifier")]
    public float ManaModifier { get; init; }

    [JsonPropertyName("armorModifier")]
    public float ArmorModifier { get; init; }

    [JsonPropertyName("damageModifier")]
    public float DamageModifier { get; init; }

    [JsonPropertyName("creatureDifficultyId")]
    public int CreatureDifficultyId { get; init; }

    [JsonPropertyName("typeFlags")]
    public uint TypeFlags { get; init; }

    [JsonPropertyName("typeFlags2")]
    public uint TypeFlags2 { get; init; }

    [JsonPropertyName("lootId")]
    public uint LootId { get; init; }

    [JsonPropertyName("pickPocketLootId")]
    public uint PickPocketLootId { get; init; }

    [JsonPropertyName("skinLootId")]
    public uint SkinLootId { get; init; }

    [JsonPropertyName("goldMin")]
    public uint GoldMin { get; init; }

    [JsonPropertyName("goldMax")]
    public uint GoldMax { get; init; }

    [JsonPropertyName("staticFlags1")]
    public uint StaticFlags1 { get; init; }

    [JsonPropertyName("staticFlags2")]
    public uint StaticFlags2 { get; init; }

    [JsonPropertyName("staticFlags3")]
    public uint StaticFlags3 { get; init; }

    [JsonPropertyName("staticFlags4")]
    public uint StaticFlags4 { get; init; }

    [JsonPropertyName("staticFlags5")]
    public uint StaticFlags5 { get; init; }

    [JsonPropertyName("staticFlags6")]
    public uint StaticFlags6 { get; init; }

    [JsonPropertyName("staticFlags7")]
    public uint StaticFlags7 { get; init; }

    [JsonPropertyName("staticFlags8")]
    public uint StaticFlags8 { get; init; }
    
    [JsonConstructor]
    internal CreatureTemplateDifficulty(
        Identifier identifier,
        byte difficultyId,
        short levelScalingDeltaMin,
        short levelScalingDeltaMax,
        int contentTuningId,
        int healthScalingExpansion,
        float healthModifier,
        float manaModifier,
        float armorModifier,
        float damageModifier,
        int creatureDifficultyId,
        uint typeFlags,
        uint typeFlags2,
        uint lootId,
        uint pickPocketLootId,
        uint skinLootId,
        uint goldMin,
        uint goldMax,
        uint staticFlags1,
        uint staticFlags2,
        uint staticFlags3,
        uint staticFlags4,
        uint staticFlags5,
        uint staticFlags6,
        uint staticFlags7,
        uint staticFlags8
    ) : base(identifier) => (
        DifficultyId,
        LevelScalingDeltaMin,
        LevelScalingDeltaMax,
        ContentTuningId,
        HealthScalingExpansion,
        HealthModifier,
        ManaModifier,
        ArmorModifier,
        DamageModifier,
        CreatureDifficultyId,
        TypeFlags,
        TypeFlags2,
        LootId,
        PickPocketLootId,
        SkinLootId,
        GoldMin,
        GoldMax,
        StaticFlags1,
        StaticFlags2,
        StaticFlags3,
        StaticFlags4,
        StaticFlags5,
        StaticFlags6,
        StaticFlags7,
        StaticFlags8
    ) = (
        difficultyId,
        levelScalingDeltaMin,
        levelScalingDeltaMax,
        contentTuningId,
        healthScalingExpansion,
        healthModifier,
        manaModifier,
        armorModifier,
        damageModifier,
        creatureDifficultyId,
        typeFlags,
        typeFlags2,
        lootId,
        pickPocketLootId,
        skinLootId,
        goldMin,
        goldMax,
        staticFlags1,
        staticFlags2,
        staticFlags3,
        staticFlags4,
        staticFlags5,
        staticFlags6,
        staticFlags7,
        staticFlags8
    );

    public static ICreatureTemplateDifficultyBuilder Builder => new CreatureTemplateDifficultyBuilder();
}