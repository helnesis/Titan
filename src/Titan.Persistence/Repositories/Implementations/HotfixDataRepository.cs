using System.Data;
using Dapper;
using MySqlConnector;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Hotfixes;
using Titan.Persistence.Extensions;
using Titan.Persistence.Queries;
using Titan.Persistence.Repositories.Interfaces;

namespace Titan.Persistence.Repositories.Implementations;

public sealed class HotfixDataRepository(DatabaseProvider provider) : IHotfixDataRepository
{
    public async Task<HotfixData?> CreateOrUpdateAsync(HotfixData entity, IDbConnection connection, IDbTransaction transaction, bool update = false)
    {
        var parameters = new
        {
            Identifier = entity.Identifier.Value,
            UniqueId = entity.UniqueIdentifier.Value,
            RecordId = entity.RecordIdentifier.Value,
            entity.TableHash,
            entity.Status
        };
        
        await connection.ExecuteAsync(HotfixQueries.InsertOrUpdateHotfix, parameters, transaction: transaction);
        return await GetAsync(entity.Identifier);
    }

    public async Task<HotfixData?> GetAsync(Identifier entityIdentifier)
    {
        await using var connection = provider.GetHotfixesDatabase();
        
        await using var reader = await connection.ExecuteReaderAsync(HotfixQueries.GetHotfixById, new { Id = entityIdentifier.Value });

        HotfixData? hotfixData = null;

        var index = 0;
        
        while (await reader.ReadAsync())
        {
            hotfixData = new HotfixData(
                reader.GetUInt32(index++),
                reader.GetUInt32(index++),
                reader.GetUInt32(index++),
                reader.GetUInt32(index++),
                reader.GetEnum<HotfixStatus>(index++)
            );
        }

        return hotfixData;
    }

    public async Task<IReadOnlyCollection<HotfixData>> GetAllAsync()
    {
        await using var connection = provider.GetHotfixesDatabase();
        
        await using var reader = await connection.ExecuteReaderAsync(HotfixQueries.GetAllHotfixes);

        List<HotfixData> hotfixes = [];
        
        while (await reader.ReadAsync())
        {
            var index = 0;

            hotfixes.Add(new HotfixData(
                reader.GetUInt32(index++),
                reader.GetUInt32(index++),
                reader.GetUInt32(index++),
                reader.GetUInt32(index++),
                reader.GetEnum<HotfixStatus>(index)
            ));
        }

        return hotfixes;
    }
    
    public async Task DeleteAsync(HotfixData entity, IDbConnection connection, IDbTransaction transaction)
    {
        await connection.ExecuteAsync(HotfixQueries.DeleteHotfix, new { Id = entity.Identifier.Value });
    }

    public async Task<bool> ExistsAsync(Identifier identifier)
    {
        return await GetAsync(identifier) is not null;
    }

    public async Task<HotfixData?> GetHotfixDataByRecordIdentifierAsync(Identifier recordIdentifier)
    {
        await using var connection = provider.GetHotfixesDatabase();
        
        await using var reader = await connection.ExecuteReaderAsync(HotfixQueries.GetHotfixByRecordId, new { RecordId = recordIdentifier.Value });

        HotfixData? hotfixData = null;

        var index = 0;
        
        while (await reader.ReadAsync())
        {
            hotfixData = new HotfixData(
                reader.GetUInt32(index++),
                reader.GetUInt32(index++),
                reader.GetUInt32(index++),
                reader.GetUInt32(index++),
                reader.GetEnum<HotfixStatus>(index++)
            );
        }

        return hotfixData;
    }
}