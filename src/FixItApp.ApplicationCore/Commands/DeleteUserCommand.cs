using MediatR;
namespace FixItApp.ApplicationCore.Commands;

public class DeleteUserCommand : IRequest
{
    public string Id { get; }

    public DeleteUserCommand(string id) => Id = id;
}