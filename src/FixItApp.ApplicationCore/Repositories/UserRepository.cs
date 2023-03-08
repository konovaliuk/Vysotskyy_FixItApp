using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.Context;
using FixItApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FixItApp.ApplicationCore.Repositories;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task<List<UserEntity>> GetAllUsersAsync(CancellationToken token)
    {
        var result = await _dbContext.Users.FromSqlRaw($"SELECT * FROM FixItApp.Users").ToListAsync(token);
        return result;
    }

    public async Task<List<UserEntity>> GetAllCustomersAsync(CancellationToken token)
    {
        string str = "Customer";
        var result =  await _dbContext.Users.FromSqlRaw(
            $"SELECT u.* FROM FixItApp.Users as u RIGHT JOIN FixItApp.Roles AS r ON u.RoleId = r.Id WHERE r.Name LIKE '{str}'")
            .ToListAsync(token);
        return result;
    }

    public async Task<RoleEntity> FetchRoleByIdAsync(int id, CancellationToken token)
    {
        var result = await _dbContext.Roles.FromSqlRaw(
                $"SELECT * FROM FixItApp.Roles WHERE FixItApp.Roles.Id = {id}")
            .FirstOrDefaultAsync(token);
        return result;
    }
    
}