using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;

namespace FixItApp.ApplicationCore.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserDTO>> GetAllUsersDtoAsync(CancellationToken token)
    {
        List <UserEntity> users = await _userRepository.GetAllUsersAsync(token);
        var result = new List<UserDTO>();
        foreach (var user in users)
        {
            var role = await _userRepository.FetchRoleByIdAsync(user.RoleId, token);
            result.Add(_mapper.MapUserEntityToUserDto(user, role.Name));
        }

        return result;
    }
    
}