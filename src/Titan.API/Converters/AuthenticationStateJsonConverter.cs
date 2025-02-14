using System.Text.Json;
using System.Text.Json.Serialization;
using Titan.API.Models;

namespace Titan.API.Converters;

public sealed class AuthenticationStateJsonConverter : JsonConverter<AuthenticationState>
{
    public override AuthenticationState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var state = reader.GetString();
        
        if (state is null)
            return AuthenticationState.None;
        
        return state switch
        {
            _ when state.Equals("NONE", StringComparison.InvariantCultureIgnoreCase) => AuthenticationState.None,
            _ when state.Equals("LOGIN", StringComparison.InvariantCultureIgnoreCase) => AuthenticationState.Login,
            _ when state.Equals("LEGAL", StringComparison.InvariantCultureIgnoreCase) => AuthenticationState.Legal,
            _ when state.Equals("AUTHENTICATOR", StringComparison.InvariantCultureIgnoreCase) => AuthenticationState.Authenticator,
            _ when state.Equals("DONE", StringComparison.InvariantCultureIgnoreCase) => AuthenticationState.Done,
            
            _ => throw new NotSupportedException($"Term '{state}' is not supported for {nameof(AuthenticationState)}")
        };
    }

    public override void Write(Utf8JsonWriter writer, AuthenticationState value, JsonSerializerOptions options)
    {
        var valueAsStr = value switch
        {
            AuthenticationState.None => "NONE",
            AuthenticationState.Login => "LOGIN",
            AuthenticationState.Legal => "LEGAL",
            AuthenticationState.Authenticator => "AUTHENTICATOR",
            AuthenticationState.Done => "DONE",
            
            _ => throw new NotSupportedException($"Term '{value}' is not supported for {nameof(AuthenticationState)}") 
        };
        
        writer.WriteStringValue(valueAsStr);
    }
}