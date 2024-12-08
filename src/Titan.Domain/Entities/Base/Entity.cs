namespace Titan.Domain.Entities.Base;

public abstract record Entity(Identifier Identifier) : IEntity;