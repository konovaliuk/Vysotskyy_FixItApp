using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;
namespace FixItApp.ApplicationCore.Queries;

public class GetCustomersByMasterIdQuery : IRequest<List<UserDTO>>
{
    public string MasterId { get; }

    public GetCustomersByMasterIdQuery(string masterId)
    {
        MasterId = masterId;
    }
}