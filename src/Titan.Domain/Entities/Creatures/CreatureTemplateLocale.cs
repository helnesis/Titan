using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;
using Titan.Domain.Enums;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateLocale : Entity
{
    public Locale Locale { get; init; }
    public string MaleName { get; init; }
    public string FemaleName { get; init; }
    public string MaleSubName { get; init; }
    public string FemaleSubName { get; init; }
    internal CreatureTemplateLocale(Identifier identifier, Locale locale, string maleName, string femaleName, string maleSubname, string femaleSubname) : base(identifier)
        => (Locale, MaleName, FemaleName, MaleSubName, FemaleSubName)  =(locale, maleName, femaleName, maleSubname, femaleSubname);

    public static ICreatureTemplateLocaleBuilder Builder => new CreatureTemplateLocaleBuilder();
}