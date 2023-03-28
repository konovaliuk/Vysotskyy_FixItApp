using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserHandler(IUserRepository userRepository)
        => _userRepository = userRepository;

    public async Task Handle(DeleteUserCommand command, CancellationToken token)
    {
        try
        {
            await _userRepository.DeleteUserByIdAsync(command.Id, token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
}