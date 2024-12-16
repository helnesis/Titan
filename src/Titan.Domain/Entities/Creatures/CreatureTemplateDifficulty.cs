using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateDifficulty : Entity
{
    public byte DifficultyID { get; init; }
    public short LevelScalingDeltaMin { get; init; }
    public short LevelScalingDeltaMax { get; init; }
    public int ContentTuningID { get; init; }
    public int HealthScalingExpansion { get; init; }
    public float HealthModifier { get; init; }
    public float ManaModifier { get; init; }
    public float ArmorModifier { get; init; }
    public float DamageModifier { get; init; }
    public int CreatureDifficultyID { get; init; }
    public uint TypeFlags { get; init; }
    public uint TypeFlags2 { get; init; }
    public uint LootID { get; init; }
    public uint PickPocketLootID { get; init; }
    public uint SkinLootID { get; init; }
    public uint GoldMin { get; init; }
    public uint GoldMax { get; init; }
    public uint StaticFlags1 { get; init; }
    public uint StaticFlags2 { get; init; }
    public uint StaticFlags3 { get; init; }
    public uint StaticFlags4 { get; init; }
    public uint StaticFlags5 { get; init; }
    public uint StaticFlags6 { get; init; }
    public uint StaticFlags7 { get; init; }
    public uint StaticFlags8 { get; init; }
    internal CreatureTemplateDifficulty(
        Identifier identifier,
        byte difficultyID,
        short levelScalingDeltaMin,
        short levelScalingDeltaMax,
        int contentTuningID,
        int healthScalingExpansion,
        float healthModifier,
        float manaModifier,
        float armorModifier,
        float damageModifier,
        int creatureDifficultyID,
        uint typeFlags,
        uint typeFlags2,
        uint lootID,
        uint pickPocketLootID,
        uint skinLootID,
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
        DifficultyID,
        LevelScalingDeltaMin,
        LevelScalingDeltaMax,
        ContentTuningID,
        HealthScalingExpansion,
        HealthModifier,
        ManaModifier,
        ArmorModifier,
        DamageModifier,
        CreatureDifficultyID,
        TypeFlags,
        TypeFlags2,
        LootID,
        PickPocketLootID,
        SkinLootID,
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
        difficultyID,
        levelScalingDeltaMin,
        levelScalingDeltaMax,
        contentTuningID,
        healthScalingExpansion,
        healthModifier,
        manaModifier,
        armorModifier,
        damageModifier,
        creatureDifficultyID,
        typeFlags,
        typeFlags2,
        lootID,
        pickPocketLootID,
        skinLootID,
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
}