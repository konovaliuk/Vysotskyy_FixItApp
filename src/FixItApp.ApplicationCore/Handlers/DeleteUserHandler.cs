using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IApplicationRepository _applicationRepository;

    public DeleteUserHandler(IUserRepository userRepository, IApplicationRepository applicationRepository)
    {
        _userRepository = userRepository;
        _applicationRepository = applicationRepository;
    }

    public async Task Handle(DeleteUserCommand command, CancellationToken token)
    {
        await _userRepository.DeleteUserByIdAsync(command.Id, token);
        await _applicationRepository.UpdateAppOnMasterDelete(command.Id, token);
    }
    
}