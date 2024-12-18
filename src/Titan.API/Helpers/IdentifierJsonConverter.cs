using System.Text.Json;
using System.Text.Json.Serialization;
using Titan.Domain.Entities;

namespace Titan.API.Helpers
{
    public class IdentifierJsonConverter : JsonConverter<Identifier>
    {
        public override Identifier Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetUInt32();
        }

        public override void Write(Utf8JsonWriter writer, Identifier value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }
    }
}
