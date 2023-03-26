using FixItApp.Infrastructure.Entities;

namespace FixItApp.Infrastructure.DataTransferObjects;

public class UserExtendedDTO : UserDTO
{
    public string Password { get; set; }
}