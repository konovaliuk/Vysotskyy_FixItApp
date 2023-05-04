using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class GetApplicationByIdHandler : BaseHandler, IRequestHandler<GetApplicationByIdQuery, ApplicationExtendedDTO>
{
    private readonly IApplicationRepository _applicationRepository;

    public GetApplicationByIdHandler(IApplicationRepository applicationRepository,
        IMapper mapper, IUserRepository userRepository) : base(userRepository, mapper)
        => _applicationRepository = applicationRepository;
    

    public async Task<ApplicationExtendedDTO> Handle(GetApplicationByIdQuery request, CancellationToken cancellationToken)
    {
        var appEntity = await _applicationRepository.GetApplicationByIdAsync(
            request.Id, cancellationToken);

        var customerEntity = await _userRepository.FetchUserByIdAsync(appEntity.ClientId, cancellationToken);

        var masterEntity = new UserEntity();
        if(appEntity.MasterId != null)
            masterEntity =  await _userRepository.FetchUserByIdAsync(appEntity.MasterId, cancellationToken);

        var result = _mapper.MapAppEntityToAppDTO(appEntity,
            customerEntity.Login, masterEntity.Login);
        
        return result;
    }
}