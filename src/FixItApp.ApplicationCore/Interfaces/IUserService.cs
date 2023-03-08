using FixItApp.Infrastructure.DataTransferObjects;

namespace FixItApp.ApplicationCore.Interfaces;

public interface IUserService
{
    public Task<List<UserDTO>> GetAllUsersDtoAsync(CancellationToken token);
}