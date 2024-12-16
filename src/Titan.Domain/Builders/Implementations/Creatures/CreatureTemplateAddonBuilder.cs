using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities;

namespace Titan.Domain.Builders.Implementations.Creatures;

public sealed class CreatureTemplateAddonBuilder : ICreatureTemplateAddonBuilder
{
    private Identifier _identifier;
    private uint _pathId;
    private uint _mount;
    private uint _mountCreatureId;
    private byte _standState;
    private byte _animTier;
    private byte _visibilityFlags;
    private byte _sheathState;
    private byte _pvpFlags;
    private uint _emote;
    private short _aiAnimKit;
    private short _movementAnimKit;
    private short _meleeAnimKit;
    private byte _visibilityDistanceType;
    private string _auras = string.Empty;

    public ICreatureTemplateAddonBuilder WithIdentifier(Identifier identifier)
    {
        _identifier = identifier;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithPathId(uint pathId)
    {
        _pathId = pathId;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithMount(uint mount)
    {
        _mount = mount;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithMountCreatureId(uint mountCreatureId)
    {
        _mountCreatureId = mountCreatureId;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithStandState(byte standState)
    {
        _standState = standState;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithAnimTier(byte animTier)
    {
        _animTier = animTier;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithVisibilityFlags(byte visibilityFlags)
    {
        _visibilityFlags = visibilityFlags;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithSheathState(byte sheathState)
    {
        _sheathState = sheathState;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithPvPFlags(byte pvpFlags)
    {
        _pvpFlags = pvpFlags;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithEmote(uint emote)
    {
        _emote = emote;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithAiAnimKit(short aiAnimKit)
    {
        _aiAnimKit = aiAnimKit;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithMovementAnimKit(short movementAnimKit)
    {
        _movementAnimKit = movementAnimKit;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithMeleeAnimKit(short meleeAnimKit)
    {
        _meleeAnimKit = meleeAnimKit;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithVisibilityDistanceType(byte visibilityDistanceType)
    {
        _visibilityDistanceType = visibilityDistanceType;
        return this;
    }

    public ICreatureTemplateAddonBuilder WithAuras(params ReadOnlySpan<string?> auras)
    {
        _auras = string.Join(' ', auras);
        return this;
    }

    public CreatureTemplateAddon Build()
    {
        return new CreatureTemplateAddon(
            _identifier,
            _pathId,
            _mount,
            _mountCreatureId,
            _standState,
            _animTier,
            _visibilityFlags,
            _sheathState,
            _pvpFlags,
            _emote,
            _aiAnimKit,
            _movementAnimKit,
            _meleeAnimKit,
            _visibilityDistanceType,
            _auras
        );
    }
}