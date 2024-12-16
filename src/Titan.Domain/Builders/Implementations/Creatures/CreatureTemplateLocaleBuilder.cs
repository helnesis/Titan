using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Creatures;
using Titan.Domain.Enums;

namespace Titan.Domain.Builders.Implementations.Creatures;

public sealed class CreatureTemplateLocaleBuilder : ICreatureTemplateLocaleBuilder
{
    private Identifier _identifier;

    private Locale _locale;
    
    private string _maleName = string.Empty;
    
    private string _femaleName = string.Empty;
    
    private string _maleSubName = string.Empty;
    
    private string _femaleSubName = string.Empty;
    public CreatureTemplateLocale Build()
        => new(_identifier, _locale, _maleName, _femaleName, _maleSubName, _femaleSubName);

    public ICreatureTemplateLocaleBuilder WithIdentifier(Identifier identifier)
    {
        _identifier = identifier;
        return this;
    }

    public ICreatureTemplateLocaleBuilder WithFemaleName(string femaleName)
    {
        _femaleName = femaleName;
        return this;
    }

    public ICreatureTemplateLocaleBuilder WithFemaleSubName(string femaleSubName)
    {
        _femaleSubName = femaleSubName;
        return this;
    }

    public ICreatureTemplateLocaleBuilder WithLocale(Locale locale)
    {
        _locale = locale;
        return this;
    }

    public ICreatureTemplateLocaleBuilder WithMaleName(string maleName)
    {
        _maleName = maleName;
        return this;
    }

    public ICreatureTemplateLocaleBuilder WithMaleSubName(string maleSubName)
    {
        _maleSubName = maleSubName;
        return this;
    }
}