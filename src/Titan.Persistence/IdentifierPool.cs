using System.Collections.Frozen;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Titan.Domain;
using Titan.Domain.Entities;
using Titan.Persistence.Extensions;
using Titan.Persistence.Queries;

namespace Titan.Persistence;

public sealed class IdentifierPool(IOptions<IdentifierPoolOptions> options, DatabaseProvider provider)
{
    private readonly FrozenDictionary<AssetType, Identifier> _pools = options.Value.Pools;
    private readonly SemaphoreSlim _semaphore = new(1, 1);
    public async Task<Identifier> NextIdentifierAsync(AssetType assetType)
    {
        await _semaphore.WaitAsync();
        try
        {
            await using var connection = GetConnectionByType(assetType);
            return await connection.GetNextIdentifier(GetQueryByType(assetType), _pools[assetType]);
        }
        finally  {  _semaphore.Release(); }
    }
    
    private MySqlConnection GetConnectionByType(AssetType type) => type switch
    {
        AssetType.Creature => provider.GetWorldDatabase(),
        
        AssetType.CreatureOutfits => provider.GetWorldDatabase(),
        
        AssetType.GameObject => provider.GetWorldDatabase(),
        
        AssetType.Item => provider.GetHotfixesDatabase(),
        
        AssetType.ItemNameDescription => provider.GetHotfixesDatabase(),
        
        AssetType.HotfixData => provider.GetHotfixesDatabase(),
        
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };
    
    private static string GetQueryByType(AssetType type) => type switch
    {
        AssetType.Creature => CreatureQueries.GetNextIdentifier,
        
        AssetType.CreatureOutfits => CreatureQueries.GetNextOutfitIdentifier,
        
        AssetType.Item => ItemQueries.NextIdentifier,
        
        AssetType.ItemNameDescription => ItemQueries.GetNextItemNameDescriptionId,
        
        AssetType.GameObject => "",
        
        AssetType.HotfixData => HotfixQueries.GetNextHotfixId,
        
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };

}