using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class CreateAppHandler : BaseHandler, IRequestHandler<CreateApplicationCommand, ApplicationDTO>
{
    private readonly IApplicationRepository _applicationRepository;
    
    public CreateAppHandler(IApplicationRepository applicationRepository, IMapper mapper, IUserRepository userRepository)
        : base(userRepository, mapper) =>  _applicationRepository = applicationRepository;
   
    public async Task<ApplicationDTO> Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
    {
        UserEntity client = await _userRepository.FetchUserByLoginAsync(command.ClientLogin, cancellationToken); 
        UserEntity master = await _userRepository.FetchUserByLoginAsync(command.MasterLogin, cancellationToken);
        if (client != null && master != null)
        { 
            var app = _mapper.MapAppCommandToEntity(command, client.Id, master.Id);
            ApplicationEntity entity = await _applicationRepository.CreateApplicationAsync(app, cancellationToken);
            return _mapper.MapAppEntityToAppDTO(entity, client.Login, master.Login);
        }

        throw new InvalidDataException();
    }
}