namespace Titan.Persistence.Queries;

public static class HotfixQueries
{
    
    public const string GetNextHotfixId = "SELECT MAX(Id) + 1 FROM hotfix_data";
    
    public const string GetAllHotfixes = """
                                          SELECT hd.Id, hd.UniqueId, hd.TableHash, hd.RecordId,
                                                 hd.Status FROM hotfix_data hd
                                          """;
    
    public const string GetHotfixById = $"{GetAllHotfixes} WHERE hd.Id = @Id";
    
    
    public const string GetHotfixByUniqueId = $"{GetAllHotfixes} WHERE hd.UniqueId = @UniqueId";
    
    
    public const string GetHotfixByRecordId = $"{GetAllHotfixes} WHERE hd.RecordId = @RecordId";
    
    
    public const string GetHotfixesByTableHash = $"{GetAllHotfixes} WHERE hd.TableHash = @TableHash";
    
    
    public const string GetHotfixesByStatus = $"{GetAllHotfixes} WHERE hd.Status = @Status";
    
    
    public const string InsertOrUpdateHotfix = """
                                              INSERT INTO hotfix_data (ID, UniqueId, TableHash, RecordId, Status)
                                              VALUES (@Identifier, @UniqueId, @TableHash, @RecordId, @Status)
                                              ON DUPLICATE KEY UPDATE UniqueId = @UniqueId, TableHash = @TableHash, RecordId = @RecordId, Status = @Status
                                              """;
    
    public const string DeleteHotfix = "DELETE FROM hotfix_data WHERE Id = @Id";
}