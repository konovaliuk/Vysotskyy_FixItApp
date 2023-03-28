using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Interfaces;
using MediatR;

namespace FixItApp.ApplicationCore.Handlers;

public class DeleteApplicationHandler : IRequestHandler<DeleteApplicationCommand>
{
    private readonly IApplicationRepository _applicationRepository;

    public DeleteApplicationHandler(IApplicationRepository applicationRepository)
        => _applicationRepository = applicationRepository;


    public async Task Handle(DeleteApplicationCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await _applicationRepository.DeleteApplicationByIdAsync(command.Id, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}