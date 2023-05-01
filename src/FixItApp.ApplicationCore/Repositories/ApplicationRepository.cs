using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.Context;
using FixItApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using MySql.Data.Types;

namespace FixItApp.ApplicationCore.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly AppDbContext _dbcontext;

    public ApplicationRepository(AppDbContext dbcontext) => _dbcontext = dbcontext;

    public async Task<ApplicationEntity> CreateApplicationAsync(ApplicationEntity app, CancellationToken token)
    {
        await _dbcontext.Database.ExecuteSqlRawAsync(
            $"INSERT INTO FixItApp.Applications (Id, Title, Description, ClientId, MasterId) " +
            $"VALUES('{app.Id}'," +
            $"'{app.Title}'," +
            $"'{app.Description}'," +
            $"'{app.ClientId}'," +
            $"'8bcd828c-8e3c-46ca-a863-27ff423bbc36')" , token);
        
        return app;
    }

    public async Task<List<ApplicationEntity>> GetAllApplicationsAsync(CancellationToken token)
    {
       var result = await _dbcontext.Applications.FromSqlRaw(
            $"SELECT * FROM FixItApp.Applications").ToListAsync(token);
       return result;
    }

    public async Task DeleteApplicationByIdAsync(string id, CancellationToken token)
    {
        await _dbcontext.Database.ExecuteSqlRawAsync(
            $"DELETE FROM FixItApp.Applications WHERE FixItApp.Applications.Id = '{id}'", token);
    }

    public async Task<ApplicationEntity> GetApplicationByIdAsync(string id, CancellationToken token)
    {
        var result = await _dbcontext.Applications.FromSqlRaw(
                $"SELECT * FROM FixItApp.Applications WHERE FixItApp.Applications.Id = '{id}'")
            .FirstOrDefaultAsync(token);
        
        return result;
    }

    public async Task EditApplicationAsync(ApplicationEntity applicationEntity, CancellationToken token)
    {
        var tmp = Convert.ToDouble(applicationEntity.Price); //trouble with c sharp and sql syntx
        
        await _dbcontext.Database.ExecuteSqlRawAsync(
            $"UPDATE FixItApp.Applications " +
            $"SET FixItApp.Applications.Title = '{applicationEntity.Title}'," +
            $"FixItApp.Applications.Description = '{applicationEntity.Description}', " +
            $"FixItApp.Applications.Status = '{applicationEntity.Status}', " +
            $"FixItApp.Applications.MasterId = '{applicationEntity.MasterId}', " +
            $"FixItApp.Applications.Price = {tmp} " +
            $"WHERE FixItApp.Applications.Id = '{applicationEntity.Id}'",
            token);
    }
    
}