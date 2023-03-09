using FixItApp.Infrastructure.Entities;

namespace FixItApp.ApplicationCore.Interfaces;
public interface IUserRepository
{
    public Task<List<UserEntity>> GetAllUsersAsync(CancellationToken token);
    public Task<List<UserEntity>> GetUsersAsync(string role, CancellationToken token);
    public Task<RoleEntity> FetchRoleByIdAsync(string id, CancellationToken token);
}