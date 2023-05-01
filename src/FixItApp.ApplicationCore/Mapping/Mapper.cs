using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;

namespace FixItApp.ApplicationCore.Mapping;

public class Mapper : IMapper
{
    private readonly IPasswordHashing _passwordHashing;

    public Mapper(IPasswordHashing passwordHashing) =>
        _passwordHashing = passwordHashing;

        public UserDTO MapUserEntityToUserDto(UserEntity user, string role)
    {
        return new UserDTO
        {
            Id = user.Id, 
            Login = user.Login,
            Name = user.Name, 
            Surname = user.Surname,
            Role = role
        };
    }

    public UserEntity MapUserCommandToEntity(CreateUserCommand command, string roleId)
    {
        return new UserEntity
        {
            Id = Guid.NewGuid().ToString(),
            Name = command.Name,
            Surname = command.Surname,
            Login = command.Login,
            Password = _passwordHashing.GetHashString(command.Password),
            RoleId = roleId
        };
    }

    public ApplicationEntity MapAppCommandToEntity(CreateApplicationCommand command, string userId)
    {
        return new ApplicationEntity
        {
            Id = Guid.NewGuid().ToString(),
            Title = command.Title,
            Description = command.Description,
            ClientId = userId
        };
    }

    public ApplicationExtendedDTO MapAppEntityToAppDTO(ApplicationEntity entity, string clientLogin, string masterLogin)
    {
        return new ApplicationExtendedDTO
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            ClientLogin = clientLogin,
            MasterLogin = masterLogin,
            Price =  Convert.ToString(entity.Price),
            Status = entity.Status
        };
    }

    public ApplicationEntity MapEditAppCommandToEntity(EditApplicationCommand command, string masterId)
    {
        return new ApplicationEntity
        {
            Id = command.Id,
            Title = command.Title,
            Description = command.Desc,
            Price = Convert.ToDecimal(command.Price),
            Status = command.Status,
            MasterId = masterId
        };
    }
}