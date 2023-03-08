using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Queries;

public class GetAllUsersQuery : IRequest<List<UserDTO>>
{
    
}