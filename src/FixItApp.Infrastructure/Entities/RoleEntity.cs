namespace FixItApp.Infrastructure.Entities;

public class RoleEntity
{
    public string Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<UserEntity>? Users;
}