namespace FixItApp.Infrastructure.Entities;

public class FeedbackEntity
{
    public string Id { get; set; }

    public string Context { get; set; }

    public string ApplicationId { get; set; }

    public ApplicationEntity Application { get; set; }
}