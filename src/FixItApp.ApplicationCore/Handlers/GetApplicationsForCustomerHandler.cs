using System.Data;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class GetApplicationsForCustomerHandler : BaseHandler, IRequestHandler<GetApplicationsByCustomerIdQuery, List<ApplicationExtendedDTO>>
{
    private readonly IApplicationRepository _applicationRepository;

    public GetApplicationsForCustomerHandler(IApplicationRepository appRep,
        IUserRepository userRep, IMapper mapper) : base(userRep, mapper)
        => _applicationRepository = appRep;

    public async Task<List<ApplicationExtendedDTO>> Handle(GetApplicationsByCustomerIdQuery request,
        CancellationToken cancellationToken)
    {
        var clientEntity = await _userRepository.FetchUserByIdAsync(request.Id, cancellationToken);
        if (clientEntity != null)
        {
            var applicationEntities =
                await _applicationRepository.GetApplicationsByClientIdAsync(request.Id, cancellationToken);

            var listDTO = new List<ApplicationExtendedDTO>();

            foreach (var entity in applicationEntities)
            {
                var master = await _userRepository.FetchUserByIdAsync(entity.MasterId,
                    cancellationToken);
                listDTO.Add(_mapper.MapAppEntityToAppDTO(entity, clientEntity.Login,
                    master.Login));
            }

            return listDTO;
        }
        
        throw new DataException();
    }
}