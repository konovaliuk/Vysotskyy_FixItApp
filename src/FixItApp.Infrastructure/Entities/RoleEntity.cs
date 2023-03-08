namespace FixItApp.Infrastructure.Entities;

public class RoleEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<UserEntity>? Users;
}