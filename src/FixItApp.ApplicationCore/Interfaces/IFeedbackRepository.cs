using FixItApp.Infrastructure.Entities;

namespace FixItApp.ApplicationCore.Interfaces;

public interface IFeedbackRepository
{
    public Task CreateFeedbackAsync(FeedbackEntity entity, CancellationToken token);

    public Task<List<FeedbackEntity>> GetAllFeedBacks(CancellationToken _token);

}