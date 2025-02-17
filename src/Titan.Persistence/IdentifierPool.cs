using System.Collections.Frozen;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Titan.Domain;
using Titan.Domain.Entities;
using Titan.Persistence.Extensions;
using Titan.Persistence.Queries;

namespace Titan.Persistence;



// @TODO: Thread safety (Lock object)
public sealed class IdentifierPool(IOptions<IdentifierPoolOptions> options, DatabaseProvider provider)
{
    private readonly FrozenDictionary<AssetType, Identifier> _pools = options.Value.Pools;
    public async Task<Identifier> NextIdentifierAsync(AssetType assetType)
    {
        await using var connection = GetConnectionByType(assetType);
        return await connection.GetNextIdentifier(GetQueryByType(assetType), _pools[assetType]);
    }
    private MySqlConnection GetConnectionByType(AssetType type) => type switch
    {
        AssetType.Creature => provider.GetWorldDatabase(),
        
        AssetType.CreatureOutfits => provider.GetWorldDatabase(),
        
        AssetType.GameObject => provider.GetWorldDatabase(),
        
        AssetType.Item => provider.GetHotfixesDatabase(),
        
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };
    
    private static string GetQueryByType(AssetType type) => type switch
    {
        AssetType.Creature => CreatureQueries.GetNextIdentifier,
        
        AssetType.CreatureOutfits => CreatureQueries.GetNextOutfitIdentifier,
        
        AssetType.Item => ItemQueries.NextIdentifier,
        
        AssetType.GameObject => "",
        
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };

}