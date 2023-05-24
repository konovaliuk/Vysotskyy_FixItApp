using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;
 
public class GetItemsByIdHandler : IRequestHandler<GetItemsByIdQuery, List<ItemDTO>>
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public GetItemsByIdHandler(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }
    
    public async Task<List<ItemDTO>> Handle(GetItemsByIdQuery query, CancellationToken cancellationToken)
    {
        var entityList = await _itemRepository.GetItemsByApplicationIdAsync(
            query.ApplicationId, cancellationToken);

        var listDTO = new List<ItemDTO>();
        
        foreach (var entity in entityList)
            listDTO.Add(_mapper.MapItemEntityToDTO(entity));

        return listDTO;
    }
}