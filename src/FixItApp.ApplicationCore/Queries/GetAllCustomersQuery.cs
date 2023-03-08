using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.Queries;

public class GetAllCustomersQuery : IRequest<List<UserEntity>>
{
    
}