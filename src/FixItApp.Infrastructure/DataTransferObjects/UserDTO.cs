namespace FixItApp.Infrastructure.DataTransferObjects;

public class UserDTO
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Login { get; set; }
    
    public string Role { get; set; }
}