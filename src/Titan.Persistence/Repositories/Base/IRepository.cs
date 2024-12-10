using Titan.Domain.Entities;
using Titan.Domain.Entities.Base;

namespace Titan.Persistence.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {
        /// <summary>
        /// Inserts a new entity into the database.
        /// </summary>
        /// <param name="entity">Entity</param>
        Task CreateAsync(T entity);

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
        /// Updates an entity in the database.
        /// </summary>
        /// <param name="entity">Entity</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="entity">Entity</param>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Checks if an entity exists in the database.
        /// </summary>
        /// <param name="entity">Identifier</param>
        /// <returns>True if the entity exists, otherwise, false.</returns>
        Task<bool> ExistsAsync(Identifier identifier);
        
    }
}
