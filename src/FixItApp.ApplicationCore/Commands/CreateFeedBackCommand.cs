using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Commands;

public class CreateFeedBackCommand : IRequest
{
    public string AppId { get; }

    public string Context { get; }

    public CreateFeedBackCommand(FeedbackDTO dto)
    {
        AppId = dto.AppId;
        Context = dto.Context;
    }
}