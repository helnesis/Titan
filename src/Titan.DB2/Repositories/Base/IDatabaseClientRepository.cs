using DBCD;
using Titan.DB2.Repositories.Records.Base;
using Titan.Domain.Entities;

namespace Titan.DB2.Repositories;

public interface IDatabaseClientRepository<T> where T : DatabaseClientRecord
{
    /// <summary>
    /// Gets the storage for the DB2 file.
    /// </summary>
    IDBCDStorage? Storage { get; }
    
    /// <summary>
    /// Gets the rows for the DB2 file.
    /// </summary>
    RowConstructor? Rows { get; }
    
    /// <summary>
    /// Initializes the repository.
    /// </summary>
    void Initialize();
    
    /// <summary>
    /// Save changes to the DB2 file.
    /// </summary>
    void Save(string path);
    
    /// <summary>
    /// Inserts a record into the DB2 file.
    /// </summary>
    /// <param name="record">Record</param>
    /// <returns>True if successful, false otherwise.</returns>
    bool Insert(T record);
    
    /// <summary>
    /// Updates an existing record in the DB2 file.
    /// </summary>
    /// <param name="record">Record</param>
    /// <returns>True if successful, false otherwise.</returns>
    bool Update(T record);
    
    /// <summary>
    /// Removes a record from the DB2 file.
    /// </summary>
    /// <param name="record">Record</param>
    /// <returns>True if successful, false otherwise.</returns>
    bool Delete(T record);
    
    /// <summary>
    /// Retrieves a record from the DB2 file by its unique identifier.
    /// </summary>
    /// <param name="identifier">Unique identifier</param>
    /// <returns>Record</returns>
    T? Get(Identifier identifier);
}