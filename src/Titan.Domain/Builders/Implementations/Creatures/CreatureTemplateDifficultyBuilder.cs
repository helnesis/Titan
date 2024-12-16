using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities;

namespace Titan.Domain.Builders.Implementations.Creatures;

public class CreatureTemplateDifficultyBuilder : ICreatureTemplateDifficultyBuilder
{
    private Identifier _identifier;
    private byte _difficultyID;
    private short _levelScalingDeltaMin;
    private short _levelScalingDeltaMax;
    private int _contentTuningID;
    private int _healthScalingExpansion;
    private float _healthModifier;
    private float _manaModifier;
    private float _armorModifier;
    private float _damageModifier;
    private int _creatureDifficultyID;
    private uint _typeFlags;
    private uint _typeFlags2;
    private uint _lootID;
    private uint _pickPocketLootID;
    private uint _skinLootID;
    private uint _goldMin;
    private uint _goldMax;
    private uint _staticFlags1;
    private uint _staticFlags2;
    private uint _staticFlags3;
    private uint _staticFlags4;
    private uint _staticFlags5;
    private uint _staticFlags6;
    private uint _staticFlags7;
    private uint _staticFlags8;

    public ICreatureTemplateDifficultyBuilder WithIdentifier(Identifier identifier)
    {
        _identifier = identifier;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithDifficultyID(byte difficultyID)
    {
        _difficultyID = difficultyID;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithLevelScalingDeltaMin(short levelScalingDeltaMin)
    {
        _levelScalingDeltaMin = levelScalingDeltaMin;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithLevelScalingDeltaMax(short levelScalingDeltaMax)
    {
        _levelScalingDeltaMax = levelScalingDeltaMax;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithContentTuningID(int contentTuningID)
    {
        _contentTuningID = contentTuningID;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithHealthScalingExpansion(int healthScalingExpansion)
    {
        _healthScalingExpansion = healthScalingExpansion;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithHealthModifier(float healthModifier)
    {
        _healthModifier = healthModifier;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithManaModifier(float manaModifier)
    {
        _manaModifier = manaModifier;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithArmorModifier(float armorModifier)
    {
        _armorModifier = armorModifier;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithDamageModifier(float damageModifier)
    {
        _damageModifier = damageModifier;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithCreatureDifficultyID(int creatureDifficultyID)
    {
        _creatureDifficultyID = creatureDifficultyID;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithTypeFlags(uint typeFlags)
    {
        _typeFlags = typeFlags;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithTypeFlags2(uint typeFlags2)
    {
        _typeFlags2 = typeFlags2;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithLootID(uint lootID)
    {
        _lootID = lootID;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithPickPocketLootID(uint pickPocketLootID)
    {
        _pickPocketLootID = pickPocketLootID;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithSkinLootID(uint skinLootID)
    {
        _skinLootID = skinLootID;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithGoldMin(uint goldMin)
    {
        _goldMin = goldMin;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithGoldMax(uint goldMax)
    {
        _goldMax = goldMax;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithStaticFlags1(uint staticFlags1)
    {
        _staticFlags1 = staticFlags1;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithStaticFlags2(uint staticFlags2)
    {
        _staticFlags2 = staticFlags2;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithStaticFlags3(uint staticFlags3)
    {
        _staticFlags3 = staticFlags3;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithStaticFlags4(uint staticFlags4)
    {
        _staticFlags4 = staticFlags4;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithStaticFlags5(uint staticFlags5)
    {
        _staticFlags5 = staticFlags5;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithStaticFlags6(uint staticFlags6)
    {
        _staticFlags6 = staticFlags6;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithStaticFlags7(uint staticFlags7)
    {
        _staticFlags7 = staticFlags7;
        return this;
    }

    public ICreatureTemplateDifficultyBuilder WithStaticFlags8(uint staticFlags8)
    {
        _staticFlags8 = staticFlags8;
        return this;
    }

    public CreatureTemplateDifficulty Build()
    {
        return new CreatureTemplateDifficulty(
            _identifier,
            _difficultyID,
            _levelScalingDeltaMin,
            _levelScalingDeltaMax,
            _contentTuningID,
            _healthScalingExpansion,
            _healthModifier,
            _manaModifier,
            _armorModifier,
            _damageModifier,
            _creatureDifficultyID,
            _typeFlags,
            _typeFlags2,
            _lootID,
            _pickPocketLootID,
            _skinLootID,
            _goldMin,
            _goldMax,
            _staticFlags1,
            _staticFlags2,
            _staticFlags3,
            _staticFlags4,
            _staticFlags5,
            _staticFlags6,
            _staticFlags7,
            _staticFlags8
        );
    }
}