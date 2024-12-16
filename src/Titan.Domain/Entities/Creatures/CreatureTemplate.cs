using Titan.Domain.Entities.Base;
using Titan.Domain.Enums;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplate : Entity
{
    public IReadOnlyCollection<uint> KillCredits = new uint[2];
    public string MaleName { get; init; }
    public string FemaleName { get; init; }
    public string MaleSubName { get; init; }
    public string FemaleSubName { get; init; }
    public string IconName { get; init; }
    public int RequiredExpansion { get; init; }
    public int VignetteId { get; init; }
    public ushort Faction { get; init; }
    public CreatureFlags Flags { get; init; }
    public float SpeedWalk { get; init; }
    public float SpeedRun { get; init; }
    public float Scale { get; init; }
    public byte Classification { get; init; }
    public sbyte DamageSchool { get; init; }
    public uint BaseAttackTime { get; init; }
    public uint RangeAttackTime { get; init; }
    public uint BaseVariance { get; init; }
    public uint RangeVariance { get; init; }
    public byte UnitClass { get; init; }
    public CreatureUnitFlags UnitFlags { get; init; }
    public CreatureUnitFlags2 UnitFlags2 { get; init; }
    public CreatureUnitFlags3 UnitFlags3 { get; init; }
    public CreatureFamily Family { get; init; }
    public byte TrainerClass { get; init; }
    public CreatureType Type { get; init; }
    public uint VehiculeEntry { get; init; }
    public string AiName { get; init; }
    public CreatureMovement MovementType { get; init; }
    public float ExperienceModifier { get; init; }
    public byte RacialLeader { get; init; }
    public uint MovementId { get; init; }
    public int WidgetSetId { get; init; }
    public int WidgetSetUnitConditionId { get; init; }
    public byte RegenHealth { get; init; }
    public int CreatureImmunitiesId { get; init; }
    public CreatureExtraFlags ExtraFlags { get; init; }
    public string ScriptName { get; init; }
    public string StringId { get; init; }
    internal CreatureTemplate(
    Identifier identifier,
    IReadOnlyCollection<uint> killCredits,
    string maleName,
    string femaleName,
    string maleSubName,
    string femaleSubName,
    string iconName,
    int requiredExpansion,
    int vignetteId,
    ushort faction,
    CreatureFlags flags,
    float speedWalk,
    float speedRun,
    float scale,
    byte classification,
    sbyte damageSchool,
    uint baseAttackTime,
    uint rangeAttackTime,
    uint baseVariance,
    uint rangeVariance,
    byte unitClass,
    CreatureUnitFlags unitFlags,
    CreatureUnitFlags2 unitFlags2,
    CreatureUnitFlags3 unitFlags3,
    CreatureFamily family,
    byte trainerClass,
    CreatureType type,
    uint vehiculeEntry,
    string aiName,
    CreatureMovement movementType,
    float experienceModifier,
    byte racialLeader,
    uint movementId,
    int widgetSetId,
    int widgetSetUnitConditionId,
    byte regenHealth,
    int creatureImmunitiesId,
    CreatureExtraFlags extraFlags,
    string scriptName,
    string stringId) : base(identifier) => (
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
    UnitFlags,
    UnitFlags2,
    UnitFlags3,
    Family,
    TrainerClass,
    Type,
    VehiculeEntry,
    AiName,
    MovementType,
    ExperienceModifier,
    RacialLeader,
    MovementId,
    WidgetSetId,
    WidgetSetUnitConditionId,
    RegenHealth,
    CreatureImmunitiesId,
    ExtraFlags,
    ScriptName,
    StringId
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
    unitFlags,
    unitFlags2,
    unitFlags3,
    family,
    trainerClass,
    type,
    vehiculeEntry,
    aiName,
    movementType,
    experienceModifier,
    racialLeader,
    movementId,
    widgetSetId,
    widgetSetUnitConditionId,
    regenHealth,
    creatureImmunitiesId,
    extraFlags,
    scriptName,
    stringId
);
}