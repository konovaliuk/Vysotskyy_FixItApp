using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Commands;

public class CreateApplicationCommand :  IRequest
{
    public string Title { get; }

    public string Description { get; }

    public string ClientId { get; }

    public CreateApplicationCommand(ApplicationDTO app)
    {
        Title = app.Title;
        Description = app.Description;
        ClientId = app.ClientId;
    }
}
