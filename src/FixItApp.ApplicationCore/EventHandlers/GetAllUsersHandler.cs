using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.EventHandlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserEntity>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserEntity>> Handle(GetAllUsersQuery request, CancellationToken token)
    {
        List <UserEntity> result = await _userRepository.GetAllUsersAsync(token);
        if (result.FirstOrDefault() != null)
            return result;
        throw new Exception();
    }
}