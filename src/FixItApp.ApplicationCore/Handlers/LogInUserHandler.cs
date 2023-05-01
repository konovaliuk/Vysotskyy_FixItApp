using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class LogInUserHandler : BaseHandler, IRequestHandler<LogInUserQuery, UserDTO>
{
    private readonly IPasswordHashing _passwordHashing;
    
    public LogInUserHandler(IUserRepository userRepository, IMapper mapper, IPasswordHashing psswdHash)
        : base (userRepository, mapper) => _passwordHashing = psswdHash;
    

    public async Task<UserDTO> Handle(LogInUserQuery query, CancellationToken cancellationToken)
    {
        var userEntity = await _userRepository.FetchUserByLoginAsync(query.Login, cancellationToken);
        
        if (userEntity != null)
            if (_passwordHashing.GetHashString(query.Password) == userEntity.Password)
            {
                var role = await _userRepository.FetchRoleByIdAsync(userEntity.RoleId, cancellationToken);
                return _mapper.MapUserEntityToUserDto(userEntity, role.Name);
            }
        
        return new UserDTO();
    }
}