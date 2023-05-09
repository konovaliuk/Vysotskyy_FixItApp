using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Interfaces;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class CreateFeedBackHandler : IRequestHandler<CreateFeedBackCommand>
{
    private readonly IFeedbackRepository _feedbackRepository;
    private readonly IMapper _mapper;

    public CreateFeedBackHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
    {
        _feedbackRepository = feedbackRepository;
        _mapper = mapper;

    }
    
    public async Task Handle(CreateFeedBackCommand request, CancellationToken cancellationToken)
    {
        var feedEntity = _mapper.MapCreateFeedBackCommandToEntity(request);

        await _feedbackRepository.CreateFeedbackAsync(feedEntity, cancellationToken);
    }
}