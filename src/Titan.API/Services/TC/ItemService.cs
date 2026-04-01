using Microsoft.AspNetCore.Http.HttpResults;
using Titan.Domain.Entities;
using Titan.Domain.Entities.Items;
using Titan.Persistence.Repositories.Implementations;
using Titan.Persistence.Repositories.Interfaces;

namespace Titan.API.Services.TC;

public sealed class ItemService(IItemRepository itemRepository)
{
    public async Task<Results<Ok<ItemTemplate>, NotFound>> GetItemById(Identifier identifier)
    {
        var itemTemplate = await itemRepository.GetAsync(identifier);
        return itemTemplate is not null ? TypedResults.Ok(itemTemplate) : TypedResults.NotFound();
    }
    
    public async Task<Results<Ok<IReadOnlyCollection<ItemTemplate>>, NotFound>> GetAllItems()
    {
        var itemTemplate = await itemRepository.GetAllAsync();
        return itemTemplate is {Count: > 0} ? TypedResults.Ok(itemTemplate) : TypedResults.NotFound();
    }
    
    public async Task<Results<Ok<ItemTemplate>, NotFound>> CreateOrUpdateItem(ItemTemplate template)
    {
        var itemTemplate = await itemRepository.CreateOrUpdateAsync(template);
        return itemTemplate is not null ? TypedResults.Ok(itemTemplate) : TypedResults.NotFound();
    }
}