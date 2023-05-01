using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Queries;

public class LogInUserQuery : IRequest<UserDTO>
{
    public string Login { get; }

    public string Password { get; }

    public LogInUserQuery(string login, string password)
    {
        Login = login;
        Password = password;
    }

}