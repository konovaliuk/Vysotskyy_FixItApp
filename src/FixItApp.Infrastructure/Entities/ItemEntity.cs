namespace FixItApp.Infrastructure.Entities;

public class ItemEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Problem { get; set; }

    public int ApplicationId { get; set; }

    public ApplicationEntity Application { get; set; }
}