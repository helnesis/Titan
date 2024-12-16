using Titan.Domain.Builders.Base;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Enums;

namespace Titan.Domain.Builders.Interfaces.Creatures;

public interface ICreatureTemplateLocaleBuilder : IBuilder<CreatureTemplateLocale>
{
    ICreatureTemplateLocaleBuilder WithIdentifier(Identifier identifier);
    ICreatureTemplateLocaleBuilder WithLocale(Locale locale);
    ICreatureTemplateLocaleBuilder WithMaleName(string maleName);
    ICreatureTemplateLocaleBuilder WithFemaleName(string femaleName);
    ICreatureTemplateLocaleBuilder WithMaleSubName(string maleSubName);
    ICreatureTemplateLocaleBuilder WithFemaleSubName(string femaleSubName);
}