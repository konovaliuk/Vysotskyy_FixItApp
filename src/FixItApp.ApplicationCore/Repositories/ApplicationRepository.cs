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
            $"INSERT INTO FixItApp.Applications (Id, Title, Description, ClientId) " +
            $"VALUES('{app.Id}'," +
            $"'{app.Title}'," +
            $"'{app.Description}'," +
            $"'{app.ClientId}')", token);
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
        // var tmp = Convert.ToDouble(applicationEntity.Price); //trouble with c sharp and sql syntx
        //
        // await _dbcontext.Database.ExecuteSqlRawAsync(
        //     $"UPDATE FixItApp.Applications " +
        //     $"SET FixItApp.Applications.Title = '{applicationEntity.Title}'," +
        //     $"FixItApp.Applications.Description = '{applicationEntity.Description}', " +
        //     $"FixItApp.Applications.Status = '{applicationEntity.Status}', " +
        //     $"FixItApp.Applications.MasterId = '{applicationEntity.MasterId}', " +
        //     $"FixItApp.Applications.Price = {tmp} " +
        //     $"WHERE FixItApp.Applications.Id = '{applicationEntity.Id}'",
        //     token);

        var tmp = await _dbcontext.Applications.Where(x => x.Id == applicationEntity.Id)
            .FirstOrDefaultAsync(token);

        tmp.Title = applicationEntity.Title;
        tmp.Description = applicationEntity.Description;
        tmp.Price = applicationEntity.Price;
        tmp.Status = applicationEntity.Status;
        tmp.MasterId = applicationEntity.MasterId;
        
        _dbcontext.SaveChangesAsync(token);

    }


    public async Task<List<ApplicationEntity>> GetApplicationsByClientIdAsync(string clientId,
        CancellationToken token)
    {
        var result = await _dbcontext.Applications.FromSqlRaw(
            $"SELECT * FROM FixItApp.Applications WHERE FixItApp.Applications.ClientId = '{clientId}'")
            .ToListAsync(token);

        return result;
    }

    public async Task<List<ApplicationEntity>> GetApplicationsByMasterIdAsync(string masterId,
        CancellationToken token)
    {
        var result = await _dbcontext.Applications.FromSqlRaw(
                $"SELECT * FROM FixItApp.Applications WHERE FixItApp.Applications.MasterId = '{masterId}'")
            .ToListAsync(token);
        
        return result;
    }

    public async Task UpdateAppOnMasterDelete(string masterId, CancellationToken token)
    {
        // await _dbcontext.Database.ExecuteSqlRawAsync(
        //     $"UPDATE FixItApp.Applications" +
        //     $"SET FixItApp.Applications.MasterId = '{null}'" +
        //     $"WHERE FixItApp.Applications.MasterId = '{masterId}'", token);

        var applicationEntities = await _dbcontext.Applications
            .Where(a => a.MasterId == masterId)
            .ToListAsync(token);

        foreach (var app in applicationEntities)
            app.MasterId = null;

        _dbcontext.SaveChangesAsync(token);
    }
}