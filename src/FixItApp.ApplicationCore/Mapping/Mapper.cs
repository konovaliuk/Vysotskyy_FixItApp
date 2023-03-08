using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;
using Org.BouncyCastle.Utilities.Collections;

namespace FixItApp.ApplicationCore.Mapping;

public class Mapper : IMapper
{
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
}