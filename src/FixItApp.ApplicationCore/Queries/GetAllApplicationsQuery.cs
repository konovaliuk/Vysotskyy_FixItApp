using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Queries;

public class GetAllApplicationsQuery : IRequest<List<ApplicationDTO>>
{
    
}