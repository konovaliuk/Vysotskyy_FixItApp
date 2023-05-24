using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.Context;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FixItApp.ApplicationCore.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _dbContext;

    public ItemRepository(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task<List<ItemEntity>> GetItemsByApplicationIdAsync(string applicationId,
        CancellationToken token)
    {
        var result = await _dbContext.Items.FromSqlRaw(
                $"SELECT * FROM FixItApp.Items " +
                $"WHERE FixItApp.Items.ApplicationId = '{applicationId}';")
            .ToListAsync(token);

        return result;
    }

    public async Task CreateItemAsync(ItemEntity itemEntity, CancellationToken token)
    {
        await _dbContext.Database.ExecuteSqlRawAsync(
            $"INSERT INTO FixItApp.Items" +
            $"(Id, Name, Problem, ApplicationId)" +
            $"VALUES ('{itemEntity.Id}', '{itemEntity.Name}', " +
            $"'{itemEntity.Problem}', '{itemEntity.ApplicationId}')",token);
    }

    public async Task DeleteItemByIdAsync(string id, CancellationToken token)
    {
        await _dbContext.Database.ExecuteSqlRawAsync(
            $"DELETE FROM FixItApp.Items " +
            $"WHERE FixItApp.Items.Id = '{id}'", token);
    }
}