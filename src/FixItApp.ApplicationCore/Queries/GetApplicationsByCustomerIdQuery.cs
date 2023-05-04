using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Queries;

public class GetApplicationsByCustomerIdQuery : IRequest<List<ApplicationExtendedDTO>>
{
    public string Id { get; }

    public GetApplicationsByCustomerIdQuery(string id)
    {
        Id = id;
    }
}