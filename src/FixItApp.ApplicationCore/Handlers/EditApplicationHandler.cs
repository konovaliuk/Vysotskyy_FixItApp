using System.Data;
using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.Entities;
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
        var masterEntity = new UserEntity();
        
        if(command.MasterLogin != null)
            masterEntity = await _userRepository.FetchUserByLoginAsync(command.MasterLogin, cancellationToken);

        if (masterEntity != null)
        {
            var appEntity = _mapper.MapEditAppCommandToEntity(command, masterEntity.Id);
            await _applicationRepository.EditApplicationAsync(appEntity, cancellationToken);
        }
        else
            throw new DataException();

    }
}