using FixItApp.ApplicationCore.Commands;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;

namespace FixItApp.ApplicationCore.Interfaces;

public interface IMapper
{
    public UserDTO MapUserEntityToUserDto(UserEntity user, string role);
    public UserEntity MapUserCommandToEntity(CreateUserCommand command, string roleId);

    public ApplicationEntity MapAppCommandToEntity(CreateApplicationCommand command, string userId);

    public ApplicationExtendedDTO MapAppEntityToAppDTO(ApplicationEntity entity, string userLogin, string masterLogin);

    public ApplicationEntity MapEditAppCommandToEntity(EditApplicationCommand command, string masterId);

    public FeedbackEntity MapCreateFeedBackCommandToEntity(CreateFeedBackCommand command);

    public FeedbackDTO MapFeedbackEntityToDTO(FeedbackEntity entity, string applicationTitle, string masterLogin);

    public ItemDTO MapItemEntityToDTO(ItemEntity entity);

    public ItemEntity MapCreateItemCommandToEntity(CreateItemCommand command);
}