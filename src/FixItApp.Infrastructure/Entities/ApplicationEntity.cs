namespace FixItApp.Infrastructure.Entities;

public class ApplicationEntity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }

    public int UserId { get; set; }

    public UserEntity User { get; set; }

    public int? MasterId { get; set; }

    public UserEntity Master { get; set; }

    public IEnumerable<ItemEntity> Items { get; set; }

    public IEnumerable<FeedbackEntity> Feedbacks { get; set; }
}