using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Interfaces;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class CreateItemHandler : IRequestHandler<CreateItemCommand>
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public CreateItemHandler(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }
    
    public async Task Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var itemEntity = _mapper.MapCreateItemCommandToEntity(request);
        await _itemRepository.CreateItemAsync(itemEntity, cancellationToken);
    }
}