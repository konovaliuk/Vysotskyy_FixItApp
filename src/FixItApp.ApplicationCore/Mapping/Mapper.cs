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
        decimal? price = null;
        
        if (command.Price != null)
            price = Convert.ToDecimal(command.Price);
        
        return new ApplicationEntity
        {
            Id = command.Id,
            Title = command.Title,
            Description = command.Desc,
            Price = price,
            Status = command.Status,
            MasterId = masterId
        };
    }

    public FeedbackEntity MapCreateFeedBackCommandToEntity(CreateFeedBackCommand command)
    {
        return new FeedbackEntity
        {
            Id = Guid.NewGuid().ToString(),
            Context = command.Context,
            ApplicationId = command.AppId
        };
    }

    public FeedbackDTO MapFeedbackEntityToDTO(FeedbackEntity entity, string applicationTitle, string masterLogin)
    {
        return new FeedbackDTO
        {
            Id = entity.Id,
            Context = entity.Context,
            MasterLogin = masterLogin,
            ApplicationTitle = applicationTitle
        };
    }

    public ItemDTO MapItemEntityToDTO(ItemEntity entity)
    {
        return new ItemDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Problem = entity.Problem,
            ApplicationId = entity.ApplicationId
        };
    }

    public ItemEntity MapCreateItemCommandToEntity(CreateItemCommand command)
    {
        return new ItemEntity
        {
            Id = Guid.NewGuid().ToString(),
            Name = command.Name,
            Problem = command.Problem,
            ApplicationId = command.ApplicationId
        };
    }
}