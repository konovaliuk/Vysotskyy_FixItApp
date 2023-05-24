using MediatR;

namespace FixItApp.ApplicationCore.Commands;

public class DeleteItemCommand : IRequest
{
    public string ItemId { get; }

    public DeleteItemCommand(string itemId)
    {
        ItemId = itemId;
    }
}