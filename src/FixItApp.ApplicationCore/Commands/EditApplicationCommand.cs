using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Commands;

public class EditApplicationCommand : IRequest
{
    public string Id { get; }

    public string Title { get; }
    
    public string Desc { get; }
    
    public string? Price { get; }
    
    public string? Status { get; }
    
    public string? MasterLogin { get; }

    public EditApplicationCommand(ApplicationExtendedDTO dto)
    {
        Id = dto.Id;
        Title = dto.Title;
        Desc = dto.Description;
        Status = dto.Status;
        Price = dto.Price;
        MasterLogin = dto.MasterLogin;
    }
}
