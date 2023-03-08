using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;

namespace FixItApp.ApplicationCore.Interfaces;

public interface IMapper
{
    public UserDTO MapUserEntityToUserDto(UserEntity user, string role);
}