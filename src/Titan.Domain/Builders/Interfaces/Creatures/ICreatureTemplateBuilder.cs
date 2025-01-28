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
    ICreatureTemplateBuilder WithSpeedWalk(float speedWalk);
    ICreatureTemplateBuilder WithSpeedRun(float speedRun);
    ICreatureTemplateBuilder WithScale(float scale);
    ICreatureTemplateBuilder WithClassification(byte classification);
    ICreatureTemplateBuilder WithDamageSchool(sbyte damageSchool);
    ICreatureTemplateBuilder WithBaseAttackTime(uint baseAttackTime);
    ICreatureTemplateBuilder WithRangeAttackTime(uint rangeAttackTime);
    ICreatureTemplateBuilder WithBaseVariance(float baseVariance);
    ICreatureTemplateBuilder WithRangeVariance(float rangeVariance);
    ICreatureTemplateBuilder WithUnitClass(byte unitClass);
    ICreatureTemplateBuilder WithFamily(CreatureFamily family);
    ICreatureTemplateBuilder WithTrainerClass(byte trainerClass);
    ICreatureTemplateBuilder WithType(CreatureType type);
    ICreatureTemplateBuilder WithVehiculeEntry(uint vehicleEntry);
    ICreatureTemplateBuilder WithAiName(string aiName);
    ICreatureTemplateBuilder WithMovementType(CreatureMovement movementType);
    ICreatureTemplateBuilder WithExperienceModifier(float experienceModifier);
    ICreatureTemplateBuilder WithRacialLeader(byte racialLeader);
    ICreatureTemplateBuilder WithMovementId(uint movementId);
    ICreatureTemplateBuilder WithWidgetSetId(int widgetSetId);
    ICreatureTemplateBuilder WithWidgetSetUnitConditionId(int widgetSetUnitConditionId);
    ICreatureTemplateBuilder WithRegenHealth(byte regenHealth);
    ICreatureTemplateBuilder WithCreatureImmunitiesId(int creatureImmunitiesId);
    ICreatureTemplateBuilder WithScriptName(string scriptName);
    ICreatureTemplateBuilder WithStringId(string stringId);
    ICreatureTemplateBuilder WithFlags(CreatureTemplateFlags? flags);
    ICreatureTemplateBuilder WithAddon(CreatureTemplateAddon? addon);
    ICreatureTemplateBuilder WithGossips(IReadOnlyCollection<CreatureTemplateGossip>? gossips);
    ICreatureTemplateBuilder WithLocales(IReadOnlyDictionary<Locale, CreatureTemplateLocale>? locales);
    ICreatureTemplateBuilder WithModels(IReadOnlyCollection<CreatureTemplateModel>? models);
    ICreatureTemplateBuilder WithMovement(CreatureTemplateMovement? movement);
    ICreatureTemplateBuilder WithOutfits(IReadOnlyCollection<CreatureTemplateOutfits>? outfits);
    ICreatureTemplateBuilder WithSparrings(IReadOnlyCollection<CreatureTemplateSparring>? sparring);
    ICreatureTemplateBuilder WithSpells(IReadOnlyCollection<CreatureTemplateSpell>? spells);
    ICreatureTemplateBuilder WithEquipments(IReadOnlyCollection<CreatureEquipTemplate>? equipments);
    ICreatureTemplateBuilder WithDifficulties(IReadOnlyCollection<CreatureTemplateDifficulty>? difficulties);
    ICreatureTemplateBuilder WithResistances(IReadOnlyCollection<CreatureTemplateResistance>? resistances);
}