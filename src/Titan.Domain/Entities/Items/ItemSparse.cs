using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Items;
using Titan.Domain.Builders.Interfaces.Items;
using Titan.Domain.Entities.Base;

namespace Titan.Domain.Entities.Items;

public sealed record ItemSparse : Entity
{
    [JsonConstructor]
    internal ItemSparse(
        Identifier identifier,
        long allowableRace,
        string? description,
        string? display3,
        string? display2,
        string? display1,
        string? display,
        int expansionId,
        float dmgVariance,
        int limitCategory,
        uint durationInInventory,
        float qualityModifier,
        uint bagFamily,
        int startQuestId,
        int languageId,
        float itemRange,
        float statPercentageOfSocket1,
        float statPercentageOfSocket2,
        float statPercentageOfSocket3,
        float statPercentageOfSocket4,
        float statPercentageOfSocket5,
        float statPercentageOfSocket6,
        float statPercentageOfSocket7,
        float statPercentageOfSocket8,
        float statPercentageOfSocket9,
        float statPercentageOfSocket10,
        int statPercentEditor1,
        int statPercentEditor2,
        int statPercentEditor3,
        int statPercentEditor4,
        int statPercentEditor5,
        int statPercentEditor6,
        int statPercentEditor7,
        int statPercentEditor8,
        int statPercentEditor9,
        int statPercentEditor10,
        int stackable,
        int maxCount,
        int minReputation,
        uint requiredAbility,
        uint sellPrice,
        uint buyPrice,
        uint vendorStackCount,
        float priceVariance,
        float priceRandomValue,
        int flags1,
        int flags2,
        int flags3,
        int flags4,
        int factionRelated,
        int modifiedCraftingReagentItemId,
        int contentTuningId,
        int playerLevelToItemLevelCurveId,
        ushort itemNameDescriptionId,
        ushort requiredTransmogHoliday,
        ushort requiredHoliday,
        ushort gemProperties,
        ushort socketMatchEnchantmentId,
        ushort totemCategoryId,
        ushort instanceBound,
        ushort zoneBound1,
        ushort zoneBound2,
        ushort itemSet,
        ushort lockId,
        ushort pageId,
        ushort itemDelay,
        ushort minFactionId,
        ushort requiredSkillRank,
        ushort requiredSkill,
        ushort itemLevel,
        short allowableClass,
        byte artifactId,
        byte spellWeight,
        byte spellWeightCategory,
        byte socketType1,
        byte socketType2,
        byte socketType3,
        byte sheatheType,
        byte material,
        byte pageMaterialId,
        byte bonding,
        byte damageDamageType,
        sbyte statModifierBonusStat1,
        sbyte statModifierBonusStat2,
        sbyte statModifierBonusStat3,
        sbyte statModifierBonusStat4,
        sbyte statModifierBonusStat5,
        sbyte statModifierBonusStat6,
        sbyte statModifierBonusStat7,
        sbyte statModifierBonusStat8,
        sbyte statModifierBonusStat9,
        sbyte statModifierBonusStat10,
        byte containerSlots,
        byte requiredPvpMedal,
        byte requiredPvpRank,
        sbyte requiredLevel,
        sbyte inventoryType,
        sbyte overallQualityId)
        : base(identifier) => (
        AllowableRace,
        Description,
        Display3,
        Display2,
        Display1,
        Display,
        ExpansionId,
        DmgVariance,
        LimitCategory,
        DurationInInventory,
        QualityModifier,
        BagFamily,
        StartQuestId,
        LanguageId,
        ItemRange,
        StatPercentageOfSocket1,
        StatPercentageOfSocket2,
        StatPercentageOfSocket3,
        StatPercentageOfSocket4,
        StatPercentageOfSocket5,
        StatPercentageOfSocket6,
        StatPercentageOfSocket7,
        StatPercentageOfSocket8,
        StatPercentageOfSocket9,
        StatPercentageOfSocket10,
        StatPercentEditor1,
        StatPercentEditor2,
        StatPercentEditor3,
        StatPercentEditor4,
        StatPercentEditor5,
        StatPercentEditor6,
        StatPercentEditor7,
        StatPercentEditor8,
        StatPercentEditor9,
        StatPercentEditor10,
        Stackable,
        MaxCount,
        MinReputation,
        RequiredAbility,
        SellPrice,
        BuyPrice,
        VendorStackCount,
        PriceVariance,
        PriceRandomValue,
        Flags1,
        Flags2,
        Flags3,
        Flags4,
        FactionRelated,
        ModifiedCraftingReagentItemId,
        ContentTuningId,
        PlayerLevelToItemLevelCurveId,
        ItemNameDescriptionId,
        RequiredTransmogHoliday,
        RequiredHoliday,
        GemProperties,
        SocketMatchEnchantmentId,
        TotemCategoryId,
        InstanceBound,
        ZoneBound1,
        ZoneBound2,
        ItemSet,
        LockId,
        PageId,
        ItemDelay,
        MinFactionId,
        RequiredSkillRank,
        RequiredSkill,
        ItemLevel,
        AllowableClass,
        ArtifactId,
        SpellWeight,
        SpellWeightCategory,
        SocketType1,
        SocketType2,
        SocketType3,
        SheatheType,
        Material,
        PageMaterialId,
        Bonding,
        DamageDamageType,
        StatModifierBonusStat1,
        StatModifierBonusStat2,
        StatModifierBonusStat3,
        StatModifierBonusStat4,
        StatModifierBonusStat5,
        StatModifierBonusStat6,
        StatModifierBonusStat7,
        StatModifierBonusStat8,
        StatModifierBonusStat9,
        StatModifierBonusStat10,
        ContainerSlots,
        RequiredPvpMedal,
        RequiredPvpRank,
        RequiredLevel,
        InventoryType,
        OverallQualityId
    ) = (
        allowableRace,
        description,
        display3,
        display2,
        display1,
        display,
        expansionId,
        dmgVariance,
        limitCategory,
        durationInInventory,
        qualityModifier,
        bagFamily,
        startQuestId,
        languageId,
        itemRange,
        statPercentageOfSocket1,
        statPercentageOfSocket2,
        statPercentageOfSocket3,
        statPercentageOfSocket4,
        statPercentageOfSocket5,
        statPercentageOfSocket6,
        statPercentageOfSocket7,
        statPercentageOfSocket8,
        statPercentageOfSocket9,
        statPercentageOfSocket10,
        statPercentEditor1,
        statPercentEditor2,
        statPercentEditor3,
        statPercentEditor4,
        statPercentEditor5,
        statPercentEditor6,
        statPercentEditor7,
        statPercentEditor8,
        statPercentEditor9,
        statPercentEditor10,
        stackable,
        maxCount,
        minReputation,
        requiredAbility,
        sellPrice,
        buyPrice,
        vendorStackCount,
        priceVariance,
        priceRandomValue,
        flags1,
        flags2,
        flags3,
        flags4,
        factionRelated,
        modifiedCraftingReagentItemId,
        contentTuningId,
        playerLevelToItemLevelCurveId,
        itemNameDescriptionId,
        requiredTransmogHoliday,
        requiredHoliday,
        gemProperties,
        socketMatchEnchantmentId,
        totemCategoryId,
        instanceBound,
        zoneBound1,
        zoneBound2,
        itemSet,
        lockId,
        pageId,
        itemDelay,
        minFactionId,
        requiredSkillRank,
        requiredSkill,
        itemLevel,
        allowableClass,
        artifactId,
        spellWeight,
        spellWeightCategory,
        socketType1,
        socketType2,
        socketType3,
        sheatheType,
        material,
        pageMaterialId,
        bonding,
        damageDamageType,
        statModifierBonusStat1,
        statModifierBonusStat2,
        statModifierBonusStat3,
        statModifierBonusStat4,
        statModifierBonusStat5,
        statModifierBonusStat6,
        statModifierBonusStat7,
        statModifierBonusStat8,
        statModifierBonusStat9,
        statModifierBonusStat10,
        containerSlots,
        requiredPvpMedal,
        requiredPvpRank,
        requiredLevel,
        inventoryType,
        overallQualityId
    );


    [JsonPropertyName("allowableRace")]
    public long AllowableRace { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("display3")]
    public string? Display3 { get; init; }

    [JsonPropertyName("display2")]
    public string? Display2 { get; init; }

    [JsonPropertyName("display1")]
    public string? Display1 { get; init; }

    [JsonPropertyName("display")]
    public string? Display { get; init; }

    [JsonPropertyName("expansionId")]
    public int ExpansionId { get; init; }

    [JsonPropertyName("dmgVariance")]
    public float DmgVariance { get; init; }

    [JsonPropertyName("limitCategory")]
    public int LimitCategory { get; init; }

    [JsonPropertyName("durationInInventory")]
    public uint DurationInInventory { get; init; }

    [JsonPropertyName("qualityModifier")]
    public float QualityModifier { get; init; }

    [JsonPropertyName("bagFamily")]
    public uint BagFamily { get; init; }

    [JsonPropertyName("startQuestId")]
    public int StartQuestId { get; init; }

    [JsonPropertyName("languageId")]
    public int LanguageId { get; init; }

    [JsonPropertyName("itemRange")]
    public float ItemRange { get; init; }

    [JsonPropertyName("statPercentageOfSocket1")]
    public float StatPercentageOfSocket1 { get; init; }

    [JsonPropertyName("statPercentageOfSocket2")]
    public float StatPercentageOfSocket2 { get; init; }

    [JsonPropertyName("statPercentageOfSocket3")]
    public float StatPercentageOfSocket3 { get; init; }

    [JsonPropertyName("statPercentageOfSocket4")]
    public float StatPercentageOfSocket4 { get; init; }

    [JsonPropertyName("statPercentageOfSocket5")]
    public float StatPercentageOfSocket5 { get; init; }

    [JsonPropertyName("statPercentageOfSocket6")]
    public float StatPercentageOfSocket6 { get; init; }

    [JsonPropertyName("statPercentageOfSocket7")]
    public float StatPercentageOfSocket7 { get; init; }

    [JsonPropertyName("statPercentageOfSocket8")]
    public float StatPercentageOfSocket8 { get; init; }

    [JsonPropertyName("statPercentageOfSocket9")]
    public float StatPercentageOfSocket9 { get; init; }

    [JsonPropertyName("statPercentageOfSocket10")]
    public float StatPercentageOfSocket10 { get; init; }

    [JsonPropertyName("statPercentEditor1")]
    
    public int StatPercentEditor1 { get; init; }

    [JsonPropertyName("statPercentEditor2")]
    public int StatPercentEditor2 { get; init; }

    [JsonPropertyName("statPercentEditor3")]
    public int StatPercentEditor3 { get; init; }

    [JsonPropertyName("statPercentEditor4")]
    public int StatPercentEditor4 { get; init; }

    [JsonPropertyName("statPercentEditor5")]
    public int StatPercentEditor5 { get; init; }

    [JsonPropertyName("statPercentEditor6")]
    public int StatPercentEditor6 { get; init; }

    [JsonPropertyName("statPercentEditor7")]
    public int StatPercentEditor7 { get; init; }

    [JsonPropertyName("statPercentEditor8")]
    public int StatPercentEditor8 { get; init; }

    [JsonPropertyName("statPercentEditor9")]
    public int StatPercentEditor9 { get; init; }

    [JsonPropertyName("statPercentEditor10")]
    public int StatPercentEditor10 { get; init; }

    [JsonPropertyName("stackable")]
    public int Stackable { get; init; }

    [JsonPropertyName("maxCount")]
    public int MaxCount { get; init; }

    [JsonPropertyName("minReputation")]
    public int MinReputation { get; init; }

    [JsonPropertyName("requiredAbility")]
    public uint RequiredAbility { get; init; }

    [JsonPropertyName("sellPrice")]
    public uint SellPrice { get; init; }

    [JsonPropertyName("buyPrice")]
    public uint BuyPrice { get; init; }

    [JsonPropertyName("vendorStackCount")]
    public uint VendorStackCount { get; init; }

    [JsonPropertyName("priceVariance")]
    public float PriceVariance { get; init; }

    [JsonPropertyName("priceRandomValue")]
    public float PriceRandomValue { get; init; }

    [JsonPropertyName("flags1")]
    public int Flags1 { get; init; }

    [JsonPropertyName("flags2")]
    public int Flags2 { get; init; }

    [JsonPropertyName("flags3")]
    public int Flags3 { get; init; }

    [JsonPropertyName("flags4")]
    public int Flags4 { get; init; }

    [JsonPropertyName("factionRelated")]
    public int FactionRelated { get; init; }

    [JsonPropertyName("modifiedCraftingReagentItemId")]
    public int ModifiedCraftingReagentItemId { get; init; }

    [JsonPropertyName("contentTuningId")]
    public int ContentTuningId { get; init; }

    [JsonPropertyName("playerLevelToItemLevelCurveId")]
    public int PlayerLevelToItemLevelCurveId { get; init; }

    [JsonPropertyName("itemNameDescriptionId")]
    public ushort ItemNameDescriptionId { get; init; }

    [JsonPropertyName("requiredTransmogHoliday")]
    public ushort RequiredTransmogHoliday { get; init; }

    [JsonPropertyName("requiredHoliday")]
    public ushort RequiredHoliday { get; init; }

    [JsonPropertyName("gemProperties")]
    public ushort GemProperties { get; init; }

    [JsonPropertyName("socketMatchEnchantmentId")]
    public ushort SocketMatchEnchantmentId { get; init; }

    [JsonPropertyName("totemCategoryId")]
    public ushort TotemCategoryId { get; init; }

    [JsonPropertyName("instanceBound")]
    public ushort InstanceBound { get; init; }

    [JsonPropertyName("zoneBound1")]
    public ushort ZoneBound1 { get; init; }

    [JsonPropertyName("zoneBound2")]
    public ushort ZoneBound2 { get; init; }

    [JsonPropertyName("itemSet")]
    public ushort ItemSet { get; init; }

    [JsonPropertyName("lockId")]
    public ushort LockId { get; init; }

    [JsonPropertyName("pageId")]
    public ushort PageId { get; init; }

    [JsonPropertyName("itemDelay")]
    public ushort ItemDelay { get; init; }

    [JsonPropertyName("minFactionId")]
    public ushort MinFactionId { get; init; }

    [JsonPropertyName("requiredSkillRank")]
    public ushort RequiredSkillRank { get; init; }

    [JsonPropertyName("requiredSkill")]
    public ushort RequiredSkill { get; init; }

    [JsonPropertyName("itemLevel")]
    public ushort ItemLevel { get; init; }

    [JsonPropertyName("allowableClass")]
    public short AllowableClass { get; init; }

    [JsonPropertyName("artifactId")]
    public byte ArtifactId { get; init; }

    [JsonPropertyName("spellWeight")]
    public byte SpellWeight { get; init; }

    [JsonPropertyName("spellWeightCategory")]
    public byte SpellWeightCategory { get; init; }

    [JsonPropertyName("socketType1")]
    public byte SocketType1 { get; init; }

    [JsonPropertyName("socketType2")]
    public byte SocketType2 { get; init; }

    [JsonPropertyName("socketType3")]
    public byte SocketType3 { get; init; }

    [JsonPropertyName("sheatheType")]
    public byte SheatheType { get; init; }

    [JsonPropertyName("material")]
    public byte Material { get; init; }

    [JsonPropertyName("pageMaterialId")]
    public byte PageMaterialId { get; init; }

    [JsonPropertyName("bonding")]
    public byte Bonding { get; init; }

    [JsonPropertyName("damageDamageType")]
    public byte DamageDamageType { get; init; }

    [JsonPropertyName("statModifierBonusStat1")]
    public sbyte StatModifierBonusStat1 { get; init; }

    [JsonPropertyName("statModifierBonusStat2")]
    public sbyte StatModifierBonusStat2 { get; init; }

    [JsonPropertyName("statModifierBonusStat3")]
    public sbyte StatModifierBonusStat3 { get; init; }

    [JsonPropertyName("statModifierBonusStat4")]
    public sbyte StatModifierBonusStat4 { get; init; }

    [JsonPropertyName("statModifierBonusStat5")]
    public sbyte StatModifierBonusStat5 { get; init; }

    [JsonPropertyName("statModifierBonusStat6")]
    public sbyte StatModifierBonusStat6 { get; init; }

    [JsonPropertyName("statModifierBonusStat7")]
    public sbyte StatModifierBonusStat7 { get; init; }

    [JsonPropertyName("statModifierBonusStat8")]
    public sbyte StatModifierBonusStat8 { get; init; }

    [JsonPropertyName("statModifierBonusStat9")]
    public sbyte StatModifierBonusStat9 { get; init; }

    [JsonPropertyName("statModifierBonusStat10")]
    public sbyte StatModifierBonusStat10 { get; init; }

    [JsonPropertyName("containerSlots")]
    public byte ContainerSlots { get; init; }

    [JsonPropertyName("requiredPVPMedal")]
    public byte RequiredPvpMedal { get; init; }

    [JsonPropertyName("requiredPVPRank")]
    public byte RequiredPvpRank { get; init; }

    [JsonPropertyName("requiredLevel")]
    public sbyte RequiredLevel { get; init; }

    [JsonPropertyName("inventoryType")]
    public sbyte InventoryType { get; init; }

    [JsonPropertyName("overallQualityId")]
    public sbyte OverallQualityId { get; init; }

    public static IItemSparseBuilder Builder => new ItemSparseBuilder();
}