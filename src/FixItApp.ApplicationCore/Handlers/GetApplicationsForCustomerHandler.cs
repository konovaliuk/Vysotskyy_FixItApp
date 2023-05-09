using System.Data;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;
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
        var customerEntity = await _userRepository.FetchUserByIdAsync(request.Id, cancellationToken);
        if (customerEntity != null)
        {
            var appList = new List<ApplicationExtendedDTO>();
            var appEntities =
                await _applicationRepository.GetApplicationsByClientIdAsync(request.Id, cancellationToken);

            foreach (var item in appEntities)
            {
                var masterEntity = new UserEntity();
                
                if(item.MasterId != null)
                    masterEntity = await _userRepository.FetchUserByIdAsync(item.MasterId, cancellationToken);
                
                var appDto = _mapper.MapAppEntityToAppDTO(item, customerEntity.Login, masterEntity.Login);
                appList.Add(appDto);
            }
            
            return appList;
        }

        throw new DataException();
    }
}