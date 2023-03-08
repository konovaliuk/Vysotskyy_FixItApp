using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDTO>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken token)
    {
        List<UserEntity> userEntityList = await _userRepository.GetAllUsersAsync(token);
        var userListDto = new List<UserDTO>();
        foreach (var user in userEntityList)
        {
            var role = await _userRepository.FetchRoleByIdAsync(user.RoleId, token);
            userListDto.Add(_mapper.MapUserEntityToUserDto(user, role.Name));
        }
        
        if (userListDto.FirstOrDefault() != null)
            return userListDto;
        throw new Exception();
    }
}