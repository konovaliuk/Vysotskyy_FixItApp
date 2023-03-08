using FixItApp.Infrastructure.Entities;

namespace FixItApp.ApplicationCore.Interfaces;
public interface IUserRepository
{
    public Task<List<UserEntity>> GetAllUsersAsync(CancellationToken token);
}