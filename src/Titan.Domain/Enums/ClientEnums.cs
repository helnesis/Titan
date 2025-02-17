using System.Text.Json.Serialization;

namespace Titan.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<Locale>))]
public enum Locale : byte
{
    [JsonPropertyName("enUS")]
    EnUs = 0,
    
    [JsonPropertyName("enUS")]
    EnGb = EnUs,
    
    [JsonPropertyName("koKR")]
    KoKr = 1,
    
    [JsonPropertyName("frFR")]
    FrFr = 2,
    
    [JsonPropertyName("deDE")]
    DeDe = 3,
    
    [JsonPropertyName("enCN")]
    EnCn = 4,
    
    [JsonPropertyName("zhCN")]
    ZhCn = EnCn,
    
    [JsonPropertyName("enTW")]
    EnTw = 5,
    
    [JsonPropertyName("zhTW")]
    ZhTw = EnTw,
    
    [JsonPropertyName("esES")]
    EsEs = 6,
    
    [JsonPropertyName("esMX")]
    EsMx = 7,
    
    [JsonPropertyName("ruRU")]
    RuRu = 8,
    
    [JsonPropertyName("ptPT")]
    PtPt = 10,
    
    [JsonPropertyName("ptBR")]
    PtBr = PtPt,
    
    [JsonPropertyName("itIT")]
    ItIt = 11,
}
