using Microsoft.AspNetCore.Mvc;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.Entities;
using MediatR;

namespace FixItApp.MVC.Controllers;
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) => _mediator = mediator;
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new GetAllUsersQuery();
        var result = new List<UserEntity>();

        try
        {
            result = await _mediator.Send(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return Ok(result);
    }
}