using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;
using Titan.Domain.Enums;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplate : Entity
{
    public IReadOnlyCollection<uint> KillCredits { get; init; }
    public string MaleName { get; init; }
    public string FemaleName { get; init; }
    public string MaleSubName { get; init; }
    public string FemaleSubName { get; init; }
    public string IconName { get; init; }
    public int RequiredExpansion { get; init; }
    public int VignetteId { get; init; }
    public ushort Faction { get; init; }
    public float SpeedWalk { get; init; }
    public float SpeedRun { get; init; }
    public float Scale { get; init; }
    public byte Classification { get; init; }
    public sbyte DamageSchool { get; init; }
    public uint BaseAttackTime { get; init; }
    public uint RangeAttackTime { get; init; }
    public float BaseVariance { get; init; }
    public float RangeVariance { get; init; }
    public byte UnitClass { get; init; }
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
    public string ScriptName { get; init; }
    public string StringId { get; init; }
    public CreatureTemplateAddon Addon { get; init; }
    public CreatureTemplateMovement Movement { get; init; }
    public CreatureTemplateOutfits Outfits { get; init; }
    public CreatureTemplateSparring Sparring { get; init; }
    public CreatureTemplateFlags Flags { get; init; }
    public IReadOnlyCollection<CreatureTemplateGossip> Gossips { get; init; }
    public IReadOnlyDictionary<Locale, CreatureTemplateLocale> Locales { get; init; }
    public IReadOnlyCollection<CreatureTemplateModel> Models { get; init; }
    public IReadOnlyCollection<CreatureTemplateSpell> Spells { get; init; }

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
        CreatureTemplateFlags flags,
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
        string aiName,
        CreatureMovement movementType,
        float experienceModifier,
        byte racialLeader,
        uint movementId,
        int widgetSetId,
        int widgetSetUnitConditionId,
        byte regenHealth,
        int creatureImmunitiesId,
        string scriptName,
        string stringId,
        CreatureTemplateAddon addon,
        IReadOnlyCollection<CreatureTemplateGossip> gossips,
        IReadOnlyDictionary<Locale, CreatureTemplateLocale> locales,
        IReadOnlyCollection<CreatureTemplateModel> models,
        CreatureTemplateMovement movement,
        CreatureTemplateOutfits outfits,
        CreatureTemplateSparring sparring,
        IReadOnlyCollection<CreatureTemplateSpell> spells
    ) : base(identifier) => (
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
        ScriptName,
        StringId,
        Addon,
        Gossips,
        Locales,
        Models,
        Movement,
        Outfits,
        Sparring,
        Spells
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
        sparring,
        spells
    );
    public static ICreatureTemplateBuilder Builder => new CreatureTemplateBuilder();
}