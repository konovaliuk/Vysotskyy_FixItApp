using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Queries;

public class GetUsersQuery : IRequest<List<UserDTO>>
{
    public GetUsersQuery(string role) => Role = role;
    public string Role { get; }
}