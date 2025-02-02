using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;
using Titan.Domain.Enums;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplate : Entity
{
    [JsonPropertyName("killCredits")]
    public IReadOnlyCollection<uint>? KillCredits { get; init; }
    
    [JsonPropertyName("maleName")]
    public string? MaleName { get; init; }
    
    [JsonPropertyName("femaleName")]
    public string? FemaleName { get; init; }
    
    [JsonPropertyName("maleSubName")]
    public string? MaleSubName { get; init; }
    
    [JsonPropertyName("femaleSubName")]
    public string? FemaleSubName { get; init; }
    
    [JsonPropertyName("iconName")]
    public string? IconName { get; init; }
    
    [JsonPropertyName("requiredExpansion")]
    public int RequiredExpansion { get; init; }
    
    [JsonPropertyName("vignetteId")]
    public int VignetteId { get; init; }
    
    [JsonPropertyName("faction")]
    public ushort Faction { get; init; }
    
    [JsonPropertyName("speedWalk")]
    public float SpeedWalk { get; init; }
    
    [JsonPropertyName("speedRun")]
    public float SpeedRun { get; init; }
    
    [JsonPropertyName("scale")]
    public float Scale { get; init; }
    
    [JsonPropertyName("classification")]
    public byte Classification { get; init; }
    
    [JsonPropertyName("damageSchool")]
    public sbyte DamageSchool { get; init; }
    
    [JsonPropertyName("baseAttackTime")]
    public uint BaseAttackTime { get; init; }
    
    [JsonPropertyName("rangeAttackTime")]
    public uint RangeAttackTime { get; init; }
    
    [JsonPropertyName("baseVariance")]
    public float BaseVariance { get; init; }
    
    [JsonPropertyName("rangeVariance")]
    public float RangeVariance { get; init; }
    
    [JsonPropertyName("unitClass")]
    public byte UnitClass { get; init; }
    
    [JsonPropertyName("family")]
    public CreatureFamily Family { get; init; }
    
    [JsonPropertyName("trainerClass")]
    public byte TrainerClass { get; init; }
    
    [JsonPropertyName("type")]
    public CreatureType Type { get; init; }
    
    [JsonPropertyName("vehicleEntry")]
    public uint VehicleEntry { get; init; }
    
    [JsonPropertyName("aiName")]
    public string? AiName { get; init; }
    
    [JsonPropertyName("movementType")]
    public CreatureMovement MovementType { get; init; }
    
    [JsonPropertyName("experienceModifier")]
    public float ExperienceModifier { get; init; }
    
    [JsonPropertyName("racialLeader")]
    public byte RacialLeader { get; init; }
    
    [JsonPropertyName("movementId")]
    public uint MovementId { get; init; }
    
    [JsonPropertyName("widgetSetId")]
    public int WidgetSetId { get; init; }
    
    [JsonPropertyName("widgetSetUnitConditionId")]
    public int WidgetSetUnitConditionId { get; init; }
    
    [JsonPropertyName("regenHealth")]
    public byte RegenHealth { get; init; }
    
    [JsonPropertyName("creatureImmunitiesId")]
    public int CreatureImmunitiesId { get; init; }
    
    [JsonPropertyName("scriptName")]
    public string? ScriptName { get; init; }
    
    [JsonPropertyName("stringId")]
    public string? StringId { get; init; }
    
    [JsonPropertyName("addon")]
    public CreatureTemplateAddon? Addon { get; init; }
    
    [JsonPropertyName("movement")]
    public CreatureTemplateMovement? Movement { get; init; }
    
    [JsonPropertyName("outfits")]
    public IReadOnlyCollection<CreatureTemplateOutfits>? Outfits { get; init; }
    
    [JsonPropertyName("sparrings")]
    public IReadOnlyCollection<CreatureTemplateSparring>? Sparrings { get; init; }
    
    [JsonPropertyName("flags")]
    public CreatureTemplateFlags? Flags { get; init; }
    
    [JsonPropertyName("gossips")]
    public IReadOnlyCollection<CreatureTemplateGossip>? Gossips { get; init; }
    
    [JsonPropertyName("locales")]
    public IReadOnlyDictionary<Locale, CreatureTemplateLocale>? Locales { get; init; }
    
    [JsonPropertyName("models")]
    public IReadOnlyCollection<CreatureTemplateModel>? Models { get; init; }
    
    [JsonPropertyName("spells")]
    public IReadOnlyCollection<CreatureTemplateSpell>? Spells { get; init; }
    
    [JsonPropertyName("equipments")]
    public IReadOnlyCollection<CreatureEquipTemplate>? Equipments { get; init; }
    
    [JsonPropertyName("difficulties")]
    public IReadOnlyCollection<CreatureTemplateDifficulty>? Difficulties { get; init; }
    
    [JsonPropertyName("resistances")]
    public IReadOnlyCollection<CreatureTemplateResistance>? Resistances { get; init; }

    
    [JsonConstructor]
    internal CreatureTemplate(
        Identifier identifier,
        IReadOnlyCollection<uint>? killCredits,
        string? maleName,
        string? femaleName,
        string? maleSubName,
        string? femaleSubName,
        string? iconName,
        int requiredExpansion,
        int vignetteId,
        ushort faction,
        CreatureTemplateFlags? flags,
        float speedWalk,
        float speedRun,
        float scale,
        byte classification,
        sbyte damageSchool,
        uint baseAttackTime,
        uint rangeAttackTime,
        float baseVariance,
        float rangeVariance,
        byte unitClass,
        CreatureFamily family,
        byte trainerClass,
        CreatureType type,
        uint vehicleEntry,
        string? aiName,
        CreatureMovement movementType,
        float experienceModifier,
        byte racialLeader,
        uint movementId,
        int widgetSetId,
        int widgetSetUnitConditionId,
        byte regenHealth,
        int creatureImmunitiesId,
        string? scriptName,
        string? stringId,
        CreatureTemplateAddon? addon,
        IReadOnlyCollection<CreatureTemplateGossip>? gossips,
        IReadOnlyDictionary<Locale, CreatureTemplateLocale>? locales,
        IReadOnlyCollection<CreatureTemplateModel>? models,
        CreatureTemplateMovement? movement,
        IReadOnlyCollection<CreatureTemplateOutfits>? outfits,
        IReadOnlyCollection<CreatureTemplateSparring>? sparrings,
        IReadOnlyCollection<CreatureTemplateSpell>? spells,
        IReadOnlyCollection<CreatureEquipTemplate>? equipments,
        IReadOnlyCollection<CreatureTemplateDifficulty>? difficulties,
        IReadOnlyCollection<CreatureTemplateResistance>? resistances) : base(identifier) => (
        KillCredits,
        MaleName,
        FemaleName,
        MaleSubName,
        FemaleSubName,
        IconName,
        RequiredExpansion,
        VignetteId,
        Faction,
        Flags,
        SpeedWalk,
        SpeedRun,
        Scale,
        Classification,
        DamageSchool,
        BaseAttackTime,
        RangeAttackTime,
        BaseVariance,
        RangeVariance,
        UnitClass,
        Family,
        TrainerClass,
        Type,
        VehicleEntry,
        AiName,
        MovementType,
        ExperienceModifier,
        RacialLeader,
        MovementId,
        WidgetSetId,
        WidgetSetUnitConditionId,
        RegenHealth,
        CreatureImmunitiesId,
        ScriptName,
        StringId,
        Addon,
        Gossips,
        Locales,
        Models,
        Movement,
        Outfits,
        Sparrings,
        Spells,
        Equipments,
        Difficulties,
        Resistances
    ) = (
        killCredits,
        maleName,
        femaleName,
        maleSubName,
        femaleSubName,
        iconName,
        requiredExpansion,
        vignetteId,
        faction,
        flags,
        speedWalk,
        speedRun,
        scale,
        classification,
        damageSchool,
        baseAttackTime,
        rangeAttackTime,
        baseVariance,
        rangeVariance,
        unitClass,
        family,
        trainerClass,
        type,
        vehicleEntry,
        aiName,
        movementType,
        experienceModifier,
        racialLeader,
        movementId,
        widgetSetId,
        widgetSetUnitConditionId,
        regenHealth,
        creatureImmunitiesId,
        scriptName,
        stringId,
        addon,
        gossips,
        locales,
        models,
        movement,
        outfits,
        sparrings,
        spells,
        equipments,
        difficulties,
        resistances
    );
    public static ICreatureTemplateBuilder Builder => new CreatureTemplateBuilder();
}