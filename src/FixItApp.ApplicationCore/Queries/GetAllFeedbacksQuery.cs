using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Queries;

public class GetAllFeedbacksQuery : IRequest<List<FeedbackDTO>>
{
    
}