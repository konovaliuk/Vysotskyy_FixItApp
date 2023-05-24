using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Commands;

public class CreateItemCommand : IRequest
{
    public string ApplicationId { get; }

    public string Name { get; }

    public string Problem { get; }

    public CreateItemCommand(ItemDTO dto)
    {
        ApplicationId = dto.ApplicationId;
        Name = dto.Name;
        Problem = dto.Problem;
    }
}