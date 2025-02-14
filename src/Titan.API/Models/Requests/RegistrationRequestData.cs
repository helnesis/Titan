using System.Text.Json.Serialization;
namespace Titan.API.Models.Requests;

[method: JsonConstructor]
public sealed record RegistrationRequestData(
    [property: JsonPropertyName("username")]
    string Username,
    [property: JsonPropertyName("password")]
    byte[] Password
);