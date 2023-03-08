using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.EventHandlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDTO>>
{
    /*private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }*/

    private readonly IUserService _userService;

    public GetAllUsersHandler(IUserService userService) => _userService = userService;

    public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken token)
    {
        List<UserDTO> result = await _userService.GetAllUsersDtoAsync(token);
        if (result.FirstOrDefault() != null)
            return result;
        throw new Exception();
    }
}