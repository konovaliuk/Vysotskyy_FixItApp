using FixItApp.ApplicationCore.Commands;
using Microsoft.AspNetCore.Mvc;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;

namespace FixItApp.MVC.Controllers;

[Controller]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) => _mediator = mediator;
    
    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        List<UserDTO> result = await _mediator.Send(new GetAllUsersQuery());
        return View("~/Views/User/Users.cshtml",result);
    }

    [HttpGet("GetUsers/{role}")]
    public async Task<IActionResult> GetUsers(string role)
    {
        List<UserDTO> result = await _mediator.Send(new GetUsersQuery(role));
        return View("~/Views/User/Users.cshtml",result);
    }

    [HttpGet("CreateUser")]
    public IActionResult CreateUser()
    {
        return View("~/Views/User/CreateUser.cshtml",new UserExtendedDTO());
    }   
    
    
    [HttpPost]
    public async Task<IActionResult> AddUser(UserExtendedDTO userDto)
    {
        await _mediator.Send(new CreateUserCommand(userDto));
        return RedirectToAction("GetAllUsers");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(string id)
    {
        await _mediator.Send(new DeleteUserCommand(id));
        return RedirectToAction("GetAllUsers");
    }
}