using System.Data;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;
using Microsoft.Identity.Client;

namespace FixItApp.ApplicationCore.Handlers;

public class GetApplicationsForMasterHandler : BaseHandler,
    IRequestHandler<GetApplicationsByMasterIdQuery, List<ApplicationExtendedDTO>>
{
    private readonly IApplicationRepository _applicationRepository;

    public GetApplicationsForMasterHandler(IApplicationRepository applicationRepository,
        IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        => _applicationRepository = applicationRepository;

    public async Task<List<ApplicationExtendedDTO>> Handle(GetApplicationsByMasterIdQuery request, CancellationToken cancellationToken)
    {
        var masterEntity = await _userRepository.FetchUserByIdAsync(request.MasterId, cancellationToken);
        if (masterEntity != null)
        {
            var appList = new List<ApplicationExtendedDTO>();
            var appEntities =
                await _applicationRepository.GetApplicationsByMasterIdAsync(request.MasterId, cancellationToken);

            foreach (var item in appEntities)
            {
                var clientEntity = 
                    await _userRepository.FetchUserByIdAsync(item.ClientId, cancellationToken);
                
               var appDto = _mapper.MapAppEntityToAppDTO(item, clientEntity.Login, masterEntity.Login);
               appList.Add(appDto);
            }
            
            return appList;
        }

        throw new DataException();
    }
}