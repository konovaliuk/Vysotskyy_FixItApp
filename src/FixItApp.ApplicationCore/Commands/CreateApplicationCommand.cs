using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Commands;

public class CreateApplicationCommand : IRequest<ApplicationDTO>
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string ClientLogin { get; set; }
    
    public string MasterLogin { get; set; }

    public CreateApplicationCommand(ApplicationDTO app)
    {
        Title = app.Title;
        Description = app.Description;
        ClientLogin = app.ClientLogin;
        MasterLogin = app.MasterLogin;
    }
}