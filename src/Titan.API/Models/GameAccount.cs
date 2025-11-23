using System.Text.Json.Serialization;

namespace Titan.API.Models;

[method: JsonConstructor]
public sealed record GameAccountInfo(
    [property: JsonPropertyName("display_name")] 
    string DisplayName,
    [property: JsonPropertyName("expansion")]
    int Expansion,
    [property: JsonPropertyName("is_suspended")]
    bool IsSuspended = false,
    [property: JsonPropertyName("is_banned")]
    bool IsBanned = false,
    [property: JsonPropertyName("suspension_expires")]
    long? SuspensionExpires = -1,
    [property: JsonPropertyName("suspension_reason")]
    string? SuspensionReason = ""
 );

public sealed record GameAccountList([property: JsonPropertyName("game_accounts")] IReadOnlyCollection<GameAccountInfo> GameAccounts);