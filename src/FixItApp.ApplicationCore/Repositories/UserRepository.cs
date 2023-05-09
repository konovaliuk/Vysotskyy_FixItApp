using System.Xml.XPath;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.Context;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FixItApp.ApplicationCore.Repositories;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task<List<UserEntity>> GetAllUsersAsync(CancellationToken token)
    {
        var result = await _dbContext.Users.FromSqlRaw($"SELECT * FROM FixItApp.Users")
            .ToListAsync(token);
        return result;
    }

    public async Task<List<UserEntity>> GetUsersAsync(string role, CancellationToken token)
    {
        var result =  await _dbContext.Users.FromSqlRaw(
            $"SELECT u.* FROM FixItApp.Users as u RIGHT JOIN FixItApp.Roles AS r ON u.RoleId = r.Id WHERE r.Name LIKE '{role}'")
            .ToListAsync(token);
        return result;
    }

    public async Task<RoleEntity> FetchRoleByIdAsync(string id, CancellationToken token)
    {
        var result = await _dbContext.Roles.FromSqlRaw(
                $"SELECT * FROM FixItApp.Roles WHERE FixItApp.Roles.Id = '{id}'")
            .FirstOrDefaultAsync(token);
        return result;
    }
    
    public async Task<RoleEntity> FetchRoleByNameAsync(string name, CancellationToken token)
    {
        var result = await _dbContext.Roles.FromSqlRaw(
                $"SELECT * FROM FixItApp.Roles WHERE FixItApp.Roles.Name LIKE '{name}'")
            .FirstOrDefaultAsync(token);
        return result;
    }

    public async Task<UserEntity> CreateUserAsync(UserEntity userEntity, CancellationToken token)
    {
        await _dbContext.Database.ExecuteSqlRawAsync(
              $"INSERT INTO FixItApp.Users (Id, Name, Surname, Login, Password, RoleId) " +
              $"VALUES ('{userEntity.Id}'," +
              $" '{userEntity.Name}', " +
              $"'{userEntity.Surname}', " +
              $"'{userEntity.Login}', " +
              $"'{userEntity.Password}', " +
              $"'{userEntity.RoleId}');", token);
        
        return userEntity;
    }

    public async Task<UserEntity> FetchUserByLoginAsync(string login, CancellationToken token)
    {
       var result = await _dbContext.Users.FromSqlRaw(
               $"SELECT * FROM FixItApp.Users WHERE FixItApp.Users.Login LIKE '{login}'")
            .FirstOrDefaultAsync(token);
       return result;
    }
    
    public async Task<UserEntity> FetchUserByIdAsync(string id, CancellationToken token)
    {
        var result = await _dbContext.Users.FromSqlRaw(
                $"SELECT * FROM FixItApp.Users WHERE FixItApp.Users.Id = '{id}'")
            .FirstOrDefaultAsync(token);
        return result;
    }

    public async Task DeleteUserByIdAsync(string id, CancellationToken token)
    {
        await _dbContext.Database.ExecuteSqlRawAsync(
            $"DELETE FROM FixItApp.Users WHERE FixItApp.Users.Id = '{id}'", token);
    }

    public async Task<List<UserEntity>> GetCustomersByMasterIdAsync(string id, CancellationToken token)
    {
        var result = await  _dbContext.Users.FromSqlRaw(
            $"SELECT u.Id, u.Name, u.Surname, u.Login, u.Password, u.RoleId " +
            $"FROM FixItApp.Roles r " +
            $"INNER JOIN FixItApp.Users u ON u.RoleId = r.Id " +
            $"INNER JOIN FixItApp.Applications a ON u.Id = a.ClientId " +
            $"WHERE a.MasterId = '{id}' AND r.Name = 'Customer'")
            .ToListAsync(token);

        return result;
    }

}