namespace Titan.Domain.Entities.Base;

public interface IEntity
{
    /// <summary>
    /// Returns the entity identifier.
    /// </summary>
    public Identifier Identifier { get; }
}