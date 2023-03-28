using MediatR;

namespace FixItApp.ApplicationCore.Commands;

public class DeleteApplicationCommand : IRequest
{
    public string Id { get;}

    public DeleteApplicationCommand(string id)
        => Id = id;
}