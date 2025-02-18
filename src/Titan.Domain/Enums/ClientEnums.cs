using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Titan.Domain.Enums;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[JsonConverter(typeof(JsonStringEnumConverter<Locale>))]
public enum Locale : byte
{
    [JsonPropertyName("enUS")]
    enUS = 0,
    
    [JsonPropertyName("enUS")]
    enGB = enUS,
    
    [JsonPropertyName("koKR")]
    koKR = 1,
    
    [JsonPropertyName("frFR")]
    frFR = 2,
    
    [JsonPropertyName("deDE")]
    deDE = 3,
    
    [JsonPropertyName("enCN")]
    enCN = 4,
    
    [JsonPropertyName("zhCN")]
    zhCN = enCN,
    
    [JsonPropertyName("enTW")]
    enTW = 5,
    
    [JsonPropertyName("zhTW")]
    zhTW = enTW,
    
    [JsonPropertyName("esES")]
    esES = 6,
    
    [JsonPropertyName("esMX")]
    esMX = 7,
    
    [JsonPropertyName("ruRU")]
    ruRU = 8,
    
    [JsonPropertyName("ptPT")]
    ptPT = 10,
    
    [JsonPropertyName("ptBR")]
    ptBR = ptPT,
    
    [JsonPropertyName("itIT")]
    itIT = 11,
}
