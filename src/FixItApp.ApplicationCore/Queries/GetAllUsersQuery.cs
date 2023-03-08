using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.Queries;

public class GetAllUsersQuery : IRequest<List<UserEntity>>
{
    
}