using System.Text.Json.Serialization;

namespace Titan.API.Models.Responses;

public record LoginResponse(
    [property: JsonPropertyName("api_token")]
    string ApiToken
);