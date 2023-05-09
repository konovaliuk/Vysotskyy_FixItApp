using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.Context;
using FixItApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FixItApp.ApplicationCore.Repositories;

public class FeedbackRepository : IFeedbackRepository
{
    private readonly AppDbContext _dbcontext;

    public FeedbackRepository(AppDbContext dbcontext) => _dbcontext = dbcontext;

    public async Task CreateFeedbackAsync(FeedbackEntity entity, CancellationToken token)
    {
        await _dbcontext.Database.ExecuteSqlRawAsync(
            $"INSERT INTO FixItApp.Feedbacks (Id, Context, ApplicationId)" +
            $"VALUES ('{entity.Id}', '{entity.Context}', '{entity.ApplicationId}')", token);
    }

    public async Task<List<FeedbackEntity>> GetAllFeedBacks(CancellationToken token)
    {
        var result = await _dbcontext.Feedbacks.FromSqlRaw(
            $"SELECT * FROM FixItApp.Feedbacks").ToListAsync(token);

        return result;
    }

}