using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Enums;

namespace Titan.Domain.Builders.Interfaces.Creatures;

public interface ICreatureTemplateBuilder : IBuilder<CreatureTemplate>
{
    ICreatureTemplateBuilder WithIdentifier(Identifier identifier);

    ICreatureTemplateBuilder WithKillCredits(params ReadOnlySpan<uint> killCredits);
    ICreatureTemplateBuilder WithMaleName(string maleName);
    ICreatureTemplateBuilder WithFemaleName(string femaleName);
    ICreatureTemplateBuilder WithMaleSubName(string maleSubName);
    ICreatureTemplateBuilder WithFemaleSubName(string femaleSubName);
    ICreatureTemplateBuilder WithIconName(string iconName);
    ICreatureTemplateBuilder WithRequiredExpansion(int requiredExpansion);
    ICreatureTemplateBuilder WithVignetteId(int vignetteId);
    ICreatureTemplateBuilder WithFaction(ushort faction);
    ICreatureTemplateBuilder WithFlags(CreatureFlags flags);
    ICreatureTemplateBuilder WithSpeedWalk(float speedWalk);
    ICreatureTemplateBuilder WithSpeedRun(float speedRun);
    ICreatureTemplateBuilder WithScale(float scale);
    ICreatureTemplateBuilder WithClassification(byte classification);
    ICreatureTemplateBuilder WithDamageSchool(sbyte damageSchool);
    ICreatureTemplateBuilder WithBaseAttackTime(uint baseAttackTime);
    ICreatureTemplateBuilder WithRangeAttackTime(uint rangeAttackTime);
    ICreatureTemplateBuilder WithBaseVariance(uint baseVariance);
    ICreatureTemplateBuilder WithRangeVariance(uint rangeVariance);
    ICreatureTemplateBuilder WithUnitClass(byte unitClass);
    ICreatureTemplateBuilder WithUnitFlags(CreatureUnitFlags unitFlags);
    ICreatureTemplateBuilder WithUnitFlags2(CreatureUnitFlags2 unitFlags2);
    ICreatureTemplateBuilder WithUnitFlags3(CreatureUnitFlags3 unitFlags3);
    ICreatureTemplateBuilder WithFamily(CreatureFamily family);
    ICreatureTemplateBuilder WithTrainerClass(byte trainerClass);
    ICreatureTemplateBuilder WithType(CreatureType type);
    ICreatureTemplateBuilder WithVehiculeEntry(uint vehiculeEntry);
    ICreatureTemplateBuilder WithAiName(string aiName);
    ICreatureTemplateBuilder WithMovementType(CreatureMovement movementType);
    ICreatureTemplateBuilder WithExperienceModifier(float experienceModifier);
    ICreatureTemplateBuilder WithRacialLeader(byte racialLeader);
    ICreatureTemplateBuilder WithMovementId(uint movementId);
    ICreatureTemplateBuilder WithWidgetSetId(int widgetWithId);
    ICreatureTemplateBuilder WithWidgetSetUnitConditionId(int widgetWithUnitConditionId);
    ICreatureTemplateBuilder WithRegenHealth(byte regenHealth);
    ICreatureTemplateBuilder WithCreatureImmunitiesId(int creatureImmunitiesId);
    ICreatureTemplateBuilder WithExtraFlags(CreatureExtraFlags extraFlags);
    ICreatureTemplateBuilder WithScriptName(string scriptName);
    ICreatureTemplateBuilder WithStringId(string stringId);
}