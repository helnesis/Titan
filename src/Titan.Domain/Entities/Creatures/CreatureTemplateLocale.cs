using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;
using Titan.Domain.Enums;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateLocale : Entity
{
    [JsonPropertyName("locale")]
    public Locale Locale { get; init; }
    
    [JsonPropertyName("maleName")]
    public string MaleName { get; init; }
    
    [JsonPropertyName("femaleName")]
    public string FemaleName { get; init; }
    
    [JsonPropertyName("maleSubName")]
    public string MaleSubName { get; init; }
    
    [JsonPropertyName("femaleSubName")]
    public string FemaleSubName { get; init; }
    
    [JsonConstructor]
    internal CreatureTemplateLocale(Identifier identifier, Locale locale, string maleName, string femaleName, string maleSubname, string femaleSubname) : base(identifier)
        => (Locale, MaleName, FemaleName, MaleSubName, FemaleSubName)  =(locale, maleName, femaleName, maleSubname, femaleSubname);

    public static ICreatureTemplateLocaleBuilder Builder => new CreatureTemplateLocaleBuilder();
}