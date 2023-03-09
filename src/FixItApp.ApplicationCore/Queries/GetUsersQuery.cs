using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.Queries;

public class GetUsersQuery : IRequest<List<UserEntity>>
{
    public GetUsersQuery(string role) => Role = role;
    public string Role { get; }
}