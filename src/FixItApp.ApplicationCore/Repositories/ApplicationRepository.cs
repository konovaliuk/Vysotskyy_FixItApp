using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.Context;
using FixItApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

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
            $"'{app.MasterId}')", token);
        
        return app;
    }

    public async Task<List<ApplicationEntity>> GetAllApplicationsAsync(CancellationToken token)
    {
       var result = await _dbcontext.Applications.FromSqlRaw(
            $"SELECT * FROM FixItApp.Applications").ToListAsync(token);
       return result;
    }

}