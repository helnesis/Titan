using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities;

namespace Titan.Domain.Builders.Implementations.Creatures;

public sealed class CreatureTemplateOutfitsBuilder : ICreatureTemplateOutfitsBuilder
{
    private Identifier _identifier;
    private uint _entry;
    private uint _npcSoundsId;
    private byte _race;
    private byte _class;
    private byte _gender;
    private int _spellVisualKitId;
    private string _customizations = string.Empty;
    private long _head;
    private long _shoulders;
    private long _body;
    private long _chest;
    private long _waist;
    private long _legs;
    private long _feet;
    private long _wrists;
    private long _hands;
    private long _back;
    private long _tabard;
    private uint _headAppearance;
    private uint _shouldersAppearance;
    private uint _bodyAppearance;
    private uint _chestAppearance;
    private uint _waistAppearance;
    private uint _legsAppearance;
    private uint _feetAppearance;
    private uint _wristsAppearance;
    private uint _handsAppearance;
    private uint _backAppearance;
    private uint _tabardAppearance;
    private ulong _guildId;
    private string _description = string.Empty;

    public Identifier Identifier { get { return _identifier; } }
    public ICreatureTemplateOutfitsBuilder WithIdentifier(Identifier identifier)
    {
        _identifier = identifier;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithEntry(uint entry)
    {
        _entry = entry;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithNpcSoundsId(uint npcSoundsId)
    {
        _npcSoundsId = npcSoundsId;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithRace(byte race)
    {
        _race = race;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithClass(byte @class)
    {
        _class = @class;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithGender(byte gender)
    {
        _gender = gender;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithSpellVisualKitId(int spellVisualKitId)
    {
        _spellVisualKitId = spellVisualKitId;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithCustomizations(string customizations)
    {
        _customizations = customizations;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithHead(long head)
    {
        _head = head;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithShoulders(long shoulders)
    {
        _shoulders = shoulders;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithBody(long body)
    {
        _body = body;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithChest(long chest)
    {
        _chest = chest;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithWaist(long waist)
    {
        _waist = waist;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithLegs(long legs)
    {
        _legs = legs;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithFeet(long feet)
    {
        _feet = feet;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithWrists(long wrists)
    {
        _wrists = wrists;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithHands(long hands)
    {
        _hands = hands;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithBack(long back)
    {
        _back = back;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithTabard(long tabard)
    {
        _tabard = tabard;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithHeadAppearance(uint headAppearance)
    {
        _headAppearance = headAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithShouldersAppearance(uint shouldersAppearance)
    {
        _shouldersAppearance = shouldersAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithBodyAppearance(uint bodyAppearance)
    {
        _bodyAppearance = bodyAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithChestAppearance(uint chestAppearance)
    {
        _chestAppearance = chestAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithWaistAppearance(uint waistAppearance)
    {
        _waistAppearance = waistAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithLegsAppearance(uint legsAppearance)
    {
        _legsAppearance = legsAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithFeetAppearance(uint feetAppearance)
    {
        _feetAppearance = feetAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithWristsAppearance(uint wristsAppearance)
    {
        _wristsAppearance = wristsAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithHandsAppearance(uint handsAppearance)
    {
        _handsAppearance = handsAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithBackAppearance(uint backAppearance)
    {
        _backAppearance = backAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithTabardAppearance(uint tabardAppearance)
    {
        _tabardAppearance = tabardAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithGuildId(ulong guildId)
    {
        _guildId = guildId;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public CreatureTemplateOutfits Build()
    {
        return new CreatureTemplateOutfits(
            _identifier,
            _entry,
            _npcSoundsId,
            _race,
            _class,
            _gender,
            _spellVisualKitId,
            _customizations,
            _head,
            _shoulders,
            _body,
            _chest,
            _waist,
            _legs,
            _feet,
            _wrists,
            _hands,
            _back,
            _tabard,
            _headAppearance,
            _shouldersAppearance,
            _bodyAppearance,
            _chestAppearance,
            _waistAppearance,
            _legsAppearance,
            _feetAppearance,
            _wristsAppearance,
            _handsAppearance,
            _backAppearance,
            _tabardAppearance,
            _guildId,
            _description
        );
    }
} 