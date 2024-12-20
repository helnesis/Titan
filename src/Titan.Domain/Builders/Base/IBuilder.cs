using Titan.Domain.Entities;

namespace Titan.Domain.Builders.Base;

public interface IBuilder<out T> where T : class
{
    /// <summary>
    /// Identifier of the entity.
    /// </summary>
    Identifier Identifier { get; }

    /// <summary>
    /// Builds the underlying <c>entity</c>.
    /// </summary>
    /// <returns>Entity</returns>
    T Build();
}