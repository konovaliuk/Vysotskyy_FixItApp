using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class GetAllFeedBacksHandler : BaseHandler, IRequestHandler<GetAllFeedbacksQuery, List<FeedbackDTO>>
{
    private readonly IFeedbackRepository _feedbackRepository;
    private readonly IApplicationRepository _applicationRepository;

    public GetAllFeedBacksHandler(IFeedbackRepository feedbackRepository, IMapper mapper,
        IUserRepository userRepository, IApplicationRepository applicationRepository) : base(
        userRepository, mapper)
    {
        _feedbackRepository = feedbackRepository;
        _applicationRepository = applicationRepository;
    }
    
    public async Task<List<FeedbackDTO>> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken)
    {
        var entityList = await _feedbackRepository.GetAllFeedBacks(cancellationToken);
        
        var list = new List<FeedbackDTO>();
        
        foreach (var item in entityList)
        {
            var application = await _applicationRepository.GetApplicationByIdAsync(item.ApplicationId, 
                cancellationToken);
            var master = new UserEntity();
            if(application.MasterId != null) 
                master = await _userRepository.FetchUserByIdAsync(application.MasterId,
                cancellationToken);
                
            list.Add(_mapper.MapFeedbackEntityToDTO(item, application.Title, master.Login));
        }

        return list;
    }
}