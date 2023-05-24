using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Queries;

public class GetItemsByIdQuery : IRequest<List<ItemDTO>>
{
    public string ApplicationId { get; }

    public GetItemsByIdQuery(string id)
    {
        ApplicationId = id;
    }
}