using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;

namespace FixItApp.ApplicationCore.Interfaces;

public interface IApplicationRepository
{
    public Task<ApplicationEntity> CreateApplicationAsync(ApplicationEntity app, CancellationToken token);

    public Task<List<ApplicationEntity>> GetAllApplicationsAsync(CancellationToken token);
}