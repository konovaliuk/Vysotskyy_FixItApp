namespace FixItApp.Infrastructure.Entities;

public class ApplicationEntity
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }

    public string ClientId { get; set; }

    public UserEntity User { get; set; }

    public string? MasterId { get; set; }

    public UserEntity Master { get; set; }

    public IEnumerable<ItemEntity> Items { get; set; }

    public IEnumerable<FeedbackEntity> Feedbacks { get; set; }
}