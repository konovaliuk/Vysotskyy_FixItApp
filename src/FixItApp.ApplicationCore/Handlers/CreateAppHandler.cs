using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.DataTransferObjects;
using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;
public class CreateAppHandler : BaseHandler, IRequestHandler<CreateApplicationCommand>
{
    private readonly IApplicationRepository _applicationRepository;
    
    public CreateAppHandler(IApplicationRepository applicationRepository, IMapper mapper, IUserRepository userRepository)
        : base(userRepository, mapper) =>  _applicationRepository = applicationRepository;
   
    public async Task Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
    {
        UserEntity client = await _userRepository.FetchUserByIdAsync(command.ClientId, cancellationToken);
        if (client != null)
        { 
            var app = _mapper.MapAppCommandToEntity(command, client.Id);
            await _applicationRepository.CreateApplicationAsync(app, cancellationToken);
        }
        
    }
}