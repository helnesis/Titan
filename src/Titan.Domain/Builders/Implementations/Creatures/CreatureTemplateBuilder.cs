using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities;
using Titan.Domain.Enums;
using System;
using System.Collections.Immutable;

namespace Titan.Domain.Builders.Implementations.Creatures;

public sealed class CreatureTemplateBuilder : ICreatureTemplateBuilder
{
    private Identifier _identifier;
    private IReadOnlyCollection<uint> _killCredits = new uint[2];
    private string _maleName = string.Empty;
    private string _femaleName = string.Empty;
    private string _maleSubName = string.Empty;
    private string _femaleSubName = string.Empty;
    private string _iconName = string.Empty;
    private int _requiredExpansion;
    private int _vignetteId;
    private ushort _faction;
    private CreatureFlags _flags;
    private float _speedWalk;
    private float _speedRun;
    private float _scale;
    private byte _classification;
    private sbyte _damageSchool;
    private uint _baseAttackTime;
    private uint _rangeAttackTime;
    private float _baseVariance;
    private float _rangeVariance;
    private byte _unitClass;
    private CreatureUnitFlags _unitFlags;
    private CreatureUnitFlags2 _unitFlags2;
    private CreatureUnitFlags3 _unitFlags3;
    private CreatureFamily _family;
    private byte _trainerClass;
    private CreatureType _type;
    private uint _vehiculeEntry;
    private string _aiName = string.Empty;
    private CreatureMovement _movementType;
    private float _experienceModifier;
    private byte _racialLeader;
    private uint _movementId;
    private int _widgetSetId;
    private int _widgetSetUnitConditionId;
    private byte _regenHealth;
    private int _creatureImmunitiesId;
    private CreatureExtraFlags _extraFlags;
    private string _scriptName = string.Empty;
    private string _stringId = string.Empty;

    public ICreatureTemplateBuilder WithIdentifier(Identifier identifier)
    {
        _identifier = identifier;
        return this;
    }
    public ICreatureTemplateBuilder WithKillCredits(params ReadOnlySpan<uint> killCredits)
    {
        _killCredits = killCredits.Length > 2 ? killCredits[..2].ToImmutableArray() : killCredits.ToImmutableArray();
        return this;
    }

    public ICreatureTemplateBuilder WithMaleName(string maleName)
    {
        _maleName = maleName;
        return this;
    }

    public ICreatureTemplateBuilder WithFemaleName(string femaleName)
    {
        _femaleName = femaleName;
        return this;
    }

    public ICreatureTemplateBuilder WithMaleSubName(string maleSubName)
    {
        _maleSubName = maleSubName;
        return this;
    }

    public ICreatureTemplateBuilder WithFemaleSubName(string femaleSubName)
    {
        _femaleSubName = femaleSubName;
        return this;
    }

    public ICreatureTemplateBuilder WithIconName(string iconName)
    {
        _iconName = iconName;
        return this;
    }

    public ICreatureTemplateBuilder WithRequiredExpansion(int requiredExpansion)
    {
        _requiredExpansion = requiredExpansion;
        return this;
    }

    public ICreatureTemplateBuilder WithVignetteId(int vignetteId)
    {
        _vignetteId = vignetteId;
        return this;
    }

    public ICreatureTemplateBuilder WithFaction(ushort faction)
    {
        _faction = faction;
        return this;
    }

    public ICreatureTemplateBuilder WithFlags(CreatureFlags flags)
    {
        _flags = flags;
        return this;
    }

    public ICreatureTemplateBuilder WithSpeedWalk(float speedWalk)
    {
        _speedWalk = speedWalk;
        return this;
    }

    public ICreatureTemplateBuilder WithSpeedRun(float speedRun)
    {
        _speedRun = speedRun;
        return this;
    }

    public ICreatureTemplateBuilder WithScale(float scale)
    {
        _scale = scale;
        return this;
    }

    public ICreatureTemplateBuilder WithClassification(byte classification)
    {
        _classification = classification;
        return this;
    }

    public ICreatureTemplateBuilder WithDamageSchool(sbyte damageSchool)
    {
        _damageSchool = damageSchool;
        return this;
    }

    public ICreatureTemplateBuilder WithBaseAttackTime(uint baseAttackTime)
    {
        _baseAttackTime = baseAttackTime;
        return this;
    }

    public ICreatureTemplateBuilder WithRangeAttackTime(uint rangeAttackTime)
    {
        _rangeAttackTime = rangeAttackTime;
        return this;
    }

    public ICreatureTemplateBuilder WithBaseVariance(float baseVariance)
    {
        _baseVariance = baseVariance;
        return this;
    }

    public ICreatureTemplateBuilder WithRangeVariance(float rangeVariance)
    {
        _rangeVariance = rangeVariance;
        return this;
    }

    public ICreatureTemplateBuilder WithUnitClass(byte unitClass)
    {
        _unitClass = unitClass;
        return this;
    }

    public ICreatureTemplateBuilder WithUnitFlags(CreatureUnitFlags unitFlags)
    {
        _unitFlags = unitFlags;
        return this;
    }

    public ICreatureTemplateBuilder WithUnitFlags2(CreatureUnitFlags2 unitFlags2)
    {
        _unitFlags2 = unitFlags2;
        return this;
    }

    public ICreatureTemplateBuilder WithUnitFlags3(CreatureUnitFlags3 unitFlags3)
    {
        _unitFlags3 = unitFlags3;
        return this;
    }

    public ICreatureTemplateBuilder WithFamily(CreatureFamily family)
    {
        _family = family;
        return this;
    }

    public ICreatureTemplateBuilder WithTrainerClass(byte trainerClass)
    {
        _trainerClass = trainerClass;
        return this;
    }

    public ICreatureTemplateBuilder WithType(CreatureType type)
    {
        _type = type;
        return this;
    }

    public ICreatureTemplateBuilder WithVehiculeEntry(uint vehiculeEntry)
    {
        _vehiculeEntry = vehiculeEntry;
        return this;
    }

    public ICreatureTemplateBuilder WithAiName(string aiName)
    {
        _aiName = aiName;
        return this;
    }

    public ICreatureTemplateBuilder WithMovementType(CreatureMovement movementType)
    {
        _movementType = movementType;
        return this;
    }

    public ICreatureTemplateBuilder WithExperienceModifier(float experienceModifier)
    {
        _experienceModifier = experienceModifier;
        return this;
    }

    public ICreatureTemplateBuilder WithRacialLeader(byte racialLeader)
    {
        _racialLeader = racialLeader;
        return this;
    }

    public ICreatureTemplateBuilder WithMovementId(uint movementId)
    {
        _movementId = movementId;
        return this;
    }

    public ICreatureTemplateBuilder WithWidgetSetId(int widgetWithId)
    {
        _widgetSetId = widgetWithId;
        return this;
    }

    public ICreatureTemplateBuilder WithWidgetSetUnitConditionId(int widgetWithUnitConditionId)
    {
        _widgetSetUnitConditionId = widgetWithUnitConditionId;
        return this;
    }

    public ICreatureTemplateBuilder WithRegenHealth(byte regenHealth)
    {
        _regenHealth = regenHealth;
        return this;
    }

    public ICreatureTemplateBuilder WithCreatureImmunitiesId(int creatureImmunitiesId)
    {
        _creatureImmunitiesId = creatureImmunitiesId;
        return this;
    }

    public ICreatureTemplateBuilder WithExtraFlags(CreatureExtraFlags extraFlags)
    {
        _extraFlags = extraFlags;
        return this;
    }

    public ICreatureTemplateBuilder WithScriptName(string scriptName)
    {
        _scriptName = scriptName;
        return this;
    }

    public ICreatureTemplateBuilder WithStringId(string stringId)
    {
        _stringId = stringId;
        return this;
    }

    public CreatureTemplate Build()
    {
        return new(
            _identifier,
            _killCredits,
            _maleName,
            _femaleName,
            _maleSubName,
            _femaleSubName,
            _iconName,
            _requiredExpansion,
            _vignetteId,
            _faction,
            _flags,
            _speedWalk,
            _speedRun,
            _scale,
            _classification,
            _damageSchool,
            _baseAttackTime,
            _rangeAttackTime,
            _baseVariance,
            _rangeVariance,
            _unitClass,
            _unitFlags,
            _unitFlags2,
            _unitFlags3,
            _family,
            _trainerClass,
            _type,
            _vehiculeEntry,
            _aiName,
            _movementType,
            _experienceModifier,
            _racialLeader,
            _movementId,
            _widgetSetId,
            _widgetSetUnitConditionId,
            _regenHealth,
            _creatureImmunitiesId,
            _extraFlags,
            _scriptName,
            _stringId
        );
    }
}