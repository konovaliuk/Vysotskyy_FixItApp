namespace FixItApp.Infrastructure.Entities;

public class UserEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public int RoleId { get; set; }

    public RoleEntity Role;

    public IEnumerable<ApplicationEntity> Applications { get; set; }
}