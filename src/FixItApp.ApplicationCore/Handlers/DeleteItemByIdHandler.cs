using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Interfaces;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class DeleteItemByIdHandler : IRequestHandler<DeleteItemCommand>
{
    private readonly IItemRepository _itemRepository;

    public DeleteItemByIdHandler(IItemRepository itemRepository)
        => _itemRepository = itemRepository;

    public async Task Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        await _itemRepository.DeleteItemByIdAsync(request.ItemId, cancellationToken);
    }
}