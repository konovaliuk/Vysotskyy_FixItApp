namespace FixItApp.Infrastructure.Entities;

public class FeedbackEntity
{
    public int Id { get; set; }

    public string Context { get; set; }

    public int ApplicationId { get; set; }

    public ApplicationEntity Application { get; set; }
}