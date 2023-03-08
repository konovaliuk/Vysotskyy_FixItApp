using FixItApp.Infrastructure.Entities;

namespace FixItApp.ApplicationCore.Interfaces;
public interface IUserRepository
{
    public Task<List<UserEntity>> GetAllUsersAsync(CancellationToken token);
    public Task<List<UserEntity>> GetAllCustomersAsync(CancellationToken token);
    public Task<RoleEntity> FetchRoleByIdAsync(int id, CancellationToken token);
}