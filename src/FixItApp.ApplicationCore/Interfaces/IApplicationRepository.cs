using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;

namespace FixItApp.ApplicationCore.Interfaces;

public interface IApplicationRepository
{
    public Task<ApplicationEntity> CreateApplicationAsync(ApplicationEntity app, CancellationToken token);

    public Task<List<ApplicationEntity>> GetAllApplicationsAsync(CancellationToken token);

    public Task DeleteApplicationByIdAsync(string id, CancellationToken token);

    public Task<ApplicationEntity> GetApplicationByIdAsync(string id, CancellationToken token);

    public Task EditApplicationAsync(ApplicationEntity applicationEntity, CancellationToken token);

}