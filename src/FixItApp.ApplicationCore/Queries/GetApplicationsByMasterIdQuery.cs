using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Queries;

public class GetApplicationsByMasterIdQuery : IRequest<List<ApplicationExtendedDTO>>
{
    public GetApplicationsByMasterIdQuery(string masterId)
    {
        MasterId = masterId;
    }

    public string MasterId { get; }
}