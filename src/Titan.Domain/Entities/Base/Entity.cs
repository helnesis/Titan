using System.Text.Json.Serialization;

namespace Titan.Domain.Entities.Base;

public abstract record Entity([property: JsonPropertyOrder(-1)] Identifier Identifier) : IEntity;
