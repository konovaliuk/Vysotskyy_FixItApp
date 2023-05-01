using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Interfaces;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class EditApplicationHandler : BaseHandler, IRequestHandler<EditApplicationCommand>
{
    private readonly IApplicationRepository _applicationRepository;

    public EditApplicationHandler(IApplicationRepository applicationRepository, IMapper mapper,
        IUserRepository userRepository) : base(userRepository, mapper)
        =>  _applicationRepository = applicationRepository;
    
    public async Task Handle(EditApplicationCommand command, CancellationToken cancellationToken)
    {
        var masterEntity = await _userRepository.FetchUserByLoginAsync(command.MasterLogin, cancellationToken);
        var appEntity = _mapper.MapEditAppCommandToEntity(command, masterEntity.Id);

        await _applicationRepository.EditApplicationAsync(appEntity, cancellationToken);
    }
}