using System.Text.Json.Serialization;

namespace Titan.API.Models.Requests;

[method: JsonConstructor]
public sealed record LoginRequestData(
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("password")] byte[] Password
    );