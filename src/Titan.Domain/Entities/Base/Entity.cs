using System.Text.Json.Serialization;

namespace Titan.Domain.Entities.Base;

public abstract record Entity([property: JsonPropertyOrder(-1), JsonPropertyName("identifier")] Identifier Identifier) : IEntity;
