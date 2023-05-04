using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class GetAllApplicationsHandler : BaseHandler, IRequestHandler<GetAllApplicationsQuery, List<ApplicationExtendedDTO>>
{
    private readonly IApplicationRepository _applicationRepository;
    
    public GetAllApplicationsHandler(IApplicationRepository applicationRepository, IUserRepository userRepository, IMapper mapper) 
        : base (userRepository, mapper) => _applicationRepository = applicationRepository;
    
    public async Task<List<ApplicationExtendedDTO>> Handle(GetAllApplicationsQuery request, CancellationToken token)
    {
        List<ApplicationEntity> listAppsEntity = await _applicationRepository.GetAllApplicationsAsync(token);
        var listAppsDto = new List<ApplicationExtendedDTO>();
        foreach (var entity in listAppsEntity)
        {
            UserEntity client = await _userRepository.FetchUserByIdAsync(entity.ClientId, token);
            
            var master = new UserEntity();
            if(entity.MasterId != null)
                master = await _userRepository.FetchUserByIdAsync(entity.MasterId, token);
            
            listAppsDto.Add(_mapper.MapAppEntityToAppDTO(entity, client.Login, master.Login));
        }
        
        return listAppsDto;
    }
}