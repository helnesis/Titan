using System.Data;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Base;
using Titan.Persistence.Repositories.Interfaces;

namespace Titan.Persistence.Repositories.Base;

/// <summary>
/// This interface implements the same methods as <see cref="IRepository{T}"/> but with the addition of a connection and transaction parameter, allowing the caller to control the database connection and transaction.
/// Mainly used for shared repositories, where multiple repositories are used in the same transaction (e.g : <see cref="IHotfixDataRepository"/> which is called by each entities present in HotfixDatabase.).
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISharedRepository<T> where T : Entity
{
    /// <summary>
    /// Inserts or updates an entity in the database on duplicate key.
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <param name="connection">Connection</param>
    /// <param name="transaction">Transaction</param>
    /// <param name="update">Is an update?</param>
    Task<T?> CreateOrUpdateAsync(T entity, IDbConnection connection, IDbTransaction transaction, bool update = false);

    /// <summary>
    /// Retrieves an entity from the database.
    /// </summary>
    /// <param name="entityIdentifier">Entity identifier</param>
    /// <returns>Entity</returns>
    Task<T?> GetAsync(Identifier entityIdentifier);

    /// <summary>
    /// Retrieves all entities from the database.
    /// </summary>
    /// <returns>A collection of entities</returns>
    Task<IReadOnlyCollection<T>> GetAllAsync();

    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <param name="connection">Connection</param>
    /// <param name="transaction">Transaction</param>
    Task DeleteAsync(T entity, IDbConnection connection, IDbTransaction transaction);

    /// <summary>
    /// Checks if an entity exists in the database.
    /// </summary>
    /// <param name="identifier">Entity identifier</param>
    /// <returns>True if the entity exists, otherwise, false.</returns>
    Task<bool> ExistsAsync(Identifier identifier);
}