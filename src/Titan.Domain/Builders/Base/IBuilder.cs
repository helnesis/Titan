namespace Titan.Domain.Builders.Base;

public interface IBuilder<out T> where T : class
{
    /// <summary>
    /// Builds the underlying <c>entity</c>.
    /// </summary>
    /// <returns>Entity</returns>
    T Build();
}