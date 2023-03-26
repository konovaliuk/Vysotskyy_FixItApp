using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class CreateUserHandler : BaseHandler, IRequestHandler<CreateUserCommand, UserDTO>
{
    public CreateUserHandler(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
    {
        
    }
     
    public async Task<UserDTO> Handle(CreateUserCommand command, CancellationToken token)
    {
        RoleEntity role = await _userRepository.FetchRoleByNameAsync(command.Role, token);
        UserEntity userEntity = _mapper.MapUserCommandToEntity(command, role.Id);
        UserEntity result = await _userRepository.CreateUserAsync(userEntity, token);
        
        
        UserDTO userDto = _mapper.MapUserEntityToUserDto(result, role.Name);
        return userDto;
       
    }
}