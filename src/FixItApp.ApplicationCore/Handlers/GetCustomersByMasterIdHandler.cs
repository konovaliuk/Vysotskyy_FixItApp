using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class GetCustomersByMasterIdHandler : BaseHandler, IRequestHandler<GetCustomersByMasterIdQuery,
    List<UserDTO>>
{
    public GetCustomersByMasterIdHandler(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
    {
        
    }

    public async Task<List<UserDTO>> Handle(GetCustomersByMasterIdQuery request, CancellationToken cancellationToken)
    {
        var listEntity = await _userRepository.GetCustomersByMasterIdAsync(request.MasterId, cancellationToken);

        var listDto = new List<UserDTO>();
        foreach (var item in listEntity)
        {
            var dto = _mapper.MapUserEntityToUserDto(item, "Customer");
            listDto.Add(dto);
        }
        
        return listDto;
    }
}