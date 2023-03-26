using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Commands;

public class CreateUserCommand : IRequest<UserDTO>
{
    public string Name;
    public string Surname;
    public string Login;
    public string Password;
    public string Role;

    public CreateUserCommand(UserExtendedDTO userDto)
    {
        Name = userDto.Name;
        Surname = userDto.Surname;
        Login = userDto.Login;
        Password = userDto.Password;
        Role = userDto.Role;
    }
}