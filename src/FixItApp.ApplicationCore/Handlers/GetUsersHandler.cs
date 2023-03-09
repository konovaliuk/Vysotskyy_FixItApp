using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<UserEntity>>
{
    private readonly IUserRepository _userRepository;
    
    public GetUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<List<UserEntity>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        List <UserEntity> result = await _userRepository.GetAllCustomersAsync(request.Role, cancellationToken);
        if (result.FirstOrDefault() != null)
            return result;
        throw new Exception();
    }
}