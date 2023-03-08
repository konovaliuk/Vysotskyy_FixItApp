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


    /*public async Task<List<UserEntity>> GetAllUsersAsync()
    {
        string command = "SELECT * FROM FixItApp.Roles;";
        MySqlCommand query = new MySqlCommand(command, conn);

        var rdr = query.ExecuteReaderAsync();

        var roles = new List<RoleEntity>();

        while (rdr.)
        {
            roles.Add(new RoleEntity{Id = rdr.GetInt32(0), Name = rdr.GetString(1)} );
        }

        return Task<roles>;
    }*/
}