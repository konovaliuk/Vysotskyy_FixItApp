using FixItApp.Infrastructure.Entities;

namespace FixItApp.ApplicationCore.Interfaces;

public interface IItemRepository
{
    public Task<List<ItemEntity>> GetItemsByApplicationIdAsync(string applicationId,
        CancellationToken token);

    public Task CreateItemAsync(ItemEntity itemEntity, CancellationToken token);

    public Task DeleteItemByIdAsync(string id, CancellationToken token);
}