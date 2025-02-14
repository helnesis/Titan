using System.Text.Json.Serialization;

namespace Titan.API.Models;

public enum AuthenticationState
{
    None,
    Login,
    Legal,
    Authenticator,
    Done
}


[method: JsonConstructor]
public sealed record FormInputValue(
    [property: JsonPropertyName("input_id")]
    string InputId,
    [property: JsonPropertyName("value")] string Value
)
{
    public static FormInputValue WithAccount(string value) => new("account_name", value);
    public static FormInputValue WithPassword(string value) => new("password", value);
}


[method: JsonConstructor]
public sealed record LoginForm(
    [property: JsonPropertyName("platform_id")]
    string PlatformId,
    [property: JsonPropertyName("program_id")]
    string ProgramId,
    [property: JsonPropertyName("version")]
    string Version,
    [property: JsonPropertyName("inputs")] IReadOnlyCollection<FormInputValue> Inputs
);

[method: JsonConstructor]
public sealed record LoginResult(
    [property: JsonPropertyName("authentication_state")]
    AuthenticationState AuthenticationState,
    [property: JsonPropertyName("error_code")]
    string ErrorCode,
    [property: JsonPropertyName("error_message")]
    string ErrorMessage,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("login_ticket")]
    string LoginTicket,
    [property: JsonPropertyName("server_evidence_m2")]
    string ServerEvidenceM2,
    [property: JsonPropertyName("next_url")]
    string NextUrl
);
