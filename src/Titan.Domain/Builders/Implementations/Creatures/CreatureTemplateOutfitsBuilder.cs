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
    private uint _head;
    private uint _shoulders;
    private uint _body;
    private uint _chest;
    private uint _waist;
    private uint _legs;
    private uint _feet;
    private uint _wrists;
    private uint _hands;
    private uint _back;
    private uint _tabard;
    private long _headAppearance;
    private long _shouldersAppearance;
    private long _bodyAppearance;
    private long _chestAppearance;
    private long _waistAppearance;
    private long _legsAppearance;
    private long _feetAppearance;
    private long _wristsAppearance;
    private long _handsAppearance;
    private long _backAppearance;
    private long _tabardAppearance;
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

    public ICreatureTemplateOutfitsBuilder WithHead(uint head)
    {
        _head = head;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithShoulders(uint shoulders)
    {
        _shoulders = shoulders;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithBody(uint body)
    {
        _body = body;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithChest(uint chest)
    {
        _chest = chest;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithWaist(uint waist)
    {
        _waist = waist;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithLegs(uint legs)
    {
        _legs = legs;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithFeet(uint feet)
    {
        _feet = feet;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithWrists(uint wrists)
    {
        _wrists = wrists;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithHands(uint hands)
    {
        _hands = hands;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithBack(uint back)
    {
        _back = back;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithTabard(uint tabard)
    {
        _tabard = tabard;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithHeadAppearance(long headAppearance)
    {
        _headAppearance = headAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithShouldersAppearance(long shouldersAppearance)
    {
        _shouldersAppearance = shouldersAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithBodyAppearance(long bodyAppearance)
    {
        _bodyAppearance = bodyAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithChestAppearance(long chestAppearance)
    {
        _chestAppearance = chestAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithWaistAppearance(long waistAppearance)
    {
        _waistAppearance = waistAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithLegsAppearance(long legsAppearance)
    {
        _legsAppearance = legsAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithFeetAppearance(long feetAppearance)
    {
        _feetAppearance = feetAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithWristsAppearance(long wristsAppearance)
    {
        _wristsAppearance = wristsAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithHandsAppearance(long handsAppearance)
    {
        _handsAppearance = handsAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithBackAppearance(long backAppearance)
    {
        _backAppearance = backAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithTabardAppearance(long tabardAppearance)
    {
        _tabardAppearance = tabardAppearance;
        return this;
    }

    public ICreatureTemplateOutfitsBuilder WithGuildId(uint guildId)
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