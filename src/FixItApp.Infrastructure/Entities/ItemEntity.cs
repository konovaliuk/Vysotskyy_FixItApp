namespace FixItApp.Infrastructure.Entities;

public class ItemEntity
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Problem { get; set; }

    public string ApplicationId { get; set; }

    public ApplicationEntity Application { get; set; }
}