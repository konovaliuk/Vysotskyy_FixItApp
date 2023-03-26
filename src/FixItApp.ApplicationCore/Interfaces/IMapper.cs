using FixItApp.ApplicationCore.Commands;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;

namespace FixItApp.ApplicationCore.Interfaces;

public interface IMapper
{
    public UserDTO MapUserEntityToUserDto(UserEntity user, string role);
    public UserEntity MapUserCommandToEntity(CreateUserCommand command, string roleId);

    public ApplicationEntity MapAppCommandToEntity(CreateApplicationCommand command, string userId, string masterId);

    public ApplicationDTO MapAppEntityToAppDTO(ApplicationEntity entity, string userLogin, string masterLogin);
}