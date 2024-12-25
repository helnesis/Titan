using System.Collections.Immutable;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Enums;

namespace Titan.Domain.Builders.Implementations.Creatures;

public sealed class CreatureTemplateBuilder : ICreatureTemplateBuilder
{
    private Identifier _identifier;
    private IReadOnlyCollection<uint> _killCredits;
    private string _maleName;
    private string _femaleName;
    private string _maleSubName;
    private string _femaleSubName;
    private string _iconName;
    private int _requiredExpansion;
    private int _vignetteId;
    private ushort _faction;
    private CreatureTemplateFlags _flags;
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
    private CreatureFamily _family;
    private byte _trainerClass;
    private CreatureType _type;
    private uint _vehiculeEntry;
    private string _aiName;
    private CreatureMovement _movementType;
    private float _experienceModifier;
    private byte _racialLeader;
    private uint _movementId;
    private int _widgetSetId;
    private int _widgetSetUnitConditionId;
    private byte _regenHealth;
    private int _creatureImmunitiesId;
    private string _scriptName;
    private string _stringId;
    private CreatureTemplateAddon _addon;
    private IReadOnlyCollection<CreatureTemplateGossip> _gossips;
    private IReadOnlyDictionary<Locale, CreatureTemplateLocale> _locales;
    private IReadOnlyCollection<CreatureTemplateModel> _models;
    private CreatureTemplateMovement _movement;
    private CreatureTemplateOutfits _outfits;
    private CreatureTemplateSparring _sparring;
    private IReadOnlyCollection<CreatureTemplateSpell> _spells;

    public Identifier Identifier { get { return _identifier; } }
    public ICreatureTemplateBuilder WithIdentifier(Identifier identifier)
    {
        _identifier = identifier;
        return this;
    }

    public ICreatureTemplateBuilder WithKillCredits(params ReadOnlySpan<uint> killCredits)
    {
        _killCredits = killCredits.Length > 2 ? [..killCredits[..2]] : killCredits.ToImmutableArray(); 
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

    public ICreatureTemplateBuilder WithFlags(CreatureTemplateFlags flags)
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

    public ICreatureTemplateBuilder WithWidgetSetId(int widgetSetId)
    {
        _widgetSetId = widgetSetId;
        return this;
    }

    public ICreatureTemplateBuilder WithWidgetSetUnitConditionId(int widgetSetUnitConditionId)
    {
        _widgetSetUnitConditionId = widgetSetUnitConditionId;
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

    public ICreatureTemplateBuilder WithAddon(CreatureTemplateAddon addon)
    {
        _addon = addon;
        return this;
    }

    public ICreatureTemplateBuilder WithGossips(IReadOnlyCollection<CreatureTemplateGossip> gossips)
    {
        _gossips = gossips;
        return this;
    }

    public ICreatureTemplateBuilder WithLocales(IReadOnlyDictionary<Locale, CreatureTemplateLocale> locales)
    {
        _locales = locales;
        return this;
    }

    public ICreatureTemplateBuilder WithModels(IReadOnlyCollection<CreatureTemplateModel> models)
    {
        _models = models;
        return this;
    }

    public ICreatureTemplateBuilder WithMovement(CreatureTemplateMovement movement)
    {
        _movement = movement;
        return this;
    }

    public ICreatureTemplateBuilder WithOutfits(CreatureTemplateOutfits outfits)
    {
        _outfits = outfits;
        return this;
    }

    public ICreatureTemplateBuilder WithSparring(CreatureTemplateSparring sparring)
    {
        _sparring = sparring;
        return this;
    }

    public ICreatureTemplateBuilder WithSpells(IReadOnlyCollection<CreatureTemplateSpell> spells)
    {
        _spells = spells;
        return this;
    }
    
    public CreatureTemplate Build()
    {
        return new CreatureTemplate(
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
            _scriptName,
            _stringId,
            _addon,
            _gossips,
            _locales,
            _models,
            _movement,
            _outfits,
            _sparring,
            _spells
        );
    }
}