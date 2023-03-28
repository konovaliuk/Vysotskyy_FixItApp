using FixItApp.Infrastructure.Entities;

namespace FixItApp.ApplicationCore.Interfaces;
public interface IUserRepository
{
    public Task<List<UserEntity>> GetAllUsersAsync(CancellationToken token);
    public Task<List<UserEntity>> GetUsersAsync(string role, CancellationToken token);
    public Task<RoleEntity> FetchRoleByIdAsync(string id, CancellationToken token);

    public Task<RoleEntity> FetchRoleByNameAsync(string name, CancellationToken token);

    public Task<UserEntity> CreateUserAsync(UserEntity userEntity, CancellationToken token);

    public Task<UserEntity> FetchUserByLoginAsync(string login, CancellationToken token);

    public Task<UserEntity> FetchUserByIdAsync(string id, CancellationToken token);

    public Task DeleteUserByIdAsync(string Id, CancellationToken token);

}