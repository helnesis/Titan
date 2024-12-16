using Titan.Domain.Builders.Base;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Entities;
using System;

namespace Titan.Domain.Builders.Interfaces.Creatures;

public interface ICreatureTemplateAddonBuilder : IBuilder<CreatureTemplateAddon>
{
    ICreatureTemplateAddonBuilder WithIdentifier(Identifier identifier);
    ICreatureTemplateAddonBuilder WithPathId(uint pathId);
    ICreatureTemplateAddonBuilder WithMount(uint mount);
    ICreatureTemplateAddonBuilder WithMountCreatureId(uint mountCreatureId);
    ICreatureTemplateAddonBuilder WithStandState(byte standState);
    ICreatureTemplateAddonBuilder WithAnimTier(byte animTier);
    ICreatureTemplateAddonBuilder WithVisibilityFlags(byte visibilityFlags);
    ICreatureTemplateAddonBuilder WithSheathState(byte sheathState);
    ICreatureTemplateAddonBuilder WithPvPFlags(byte pvpFlags);
    ICreatureTemplateAddonBuilder WithEmote(uint emote);
    ICreatureTemplateAddonBuilder WithAiAnimKit(short aiAnimKit);
    ICreatureTemplateAddonBuilder WithMovementAnimKit(short movementAnimKit);
    ICreatureTemplateAddonBuilder WithMeleeAnimKit(short meleeAnimKit);
    ICreatureTemplateAddonBuilder WithVisibilityDistanceType(byte visibilityDistanceType);
    ICreatureTemplateAddonBuilder WithAuras(params ReadOnlySpan<string?> auras);
}