using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Queries;

public class GetApplicationByIdQuery : IRequest<ApplicationExtendedDTO>
{
    public string Id { get; }

    public GetApplicationByIdQuery(string id)
    {
        Id = id;
    }
}