using FixItApp.ApplicationCore.Commands;
using Microsoft.AspNetCore.Mvc;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace FixItApp.MVC.Controllers;

[Controller]
public class UserController : Controller
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) => _mediator = mediator;
    
    [HttpGet("[controller]/GetAllUsers")]
    [Authorize(Policy = "RequireManagerRole")]
    public async Task<IActionResult> GetAllUsers()
    {
        List<UserDTO> result = await _mediator.Send(new GetAllUsersQuery());
        return View("~/Views/User/Users.cshtml",result);
    }
    
    [HttpGet("[controller]/GetCustomers")]
    [Authorize(Policy = "RequireManagerRole")]
    public async Task<IActionResult> GetCustomers()
    {
        List<UserDTO> result = await _mediator.Send(new GetUsersQuery("Customer"));
        return View("~/Views/User/Users.cshtml",result);
    }
    
    [HttpGet("[controller]/GetMasters")]
    public async Task<IActionResult> GetMasters()
    {
        List<UserDTO> result = await _mediator.Send(new GetUsersQuery("Master"));
        return View("~/Views/User/Users.cshtml",result);
    }
    
    [HttpGet("[controller]/GetManagers")]
    public async Task<IActionResult> GetManagers()
    {
        List<UserDTO> result = await _mediator.Send(new GetUsersQuery("Manager"));
        return View("~/Views/User/Users.cshtml",result);
    }

    [HttpGet("[controller]/CreateUser")]
    public IActionResult CreateUser()
    {
        return View("~/Views/User/CreateUser.cshtml",new UserExtendedDTO());
    }   
    
    [HttpPost]
    public async Task<IActionResult> AddUser(UserExtendedDTO userDto)
    {
        await _mediator.Send(new CreateUserCommand(userDto));
        var userPolicy = User.Claims.FirstOrDefault(c => c.Type == "Role");
        if (userPolicy.Value == "Manager")
            return RedirectToAction("GetAllUsers");

        return RedirectToAction("LogIn", "Access");
    }
    
    [HttpPost]
    [Authorize(Policy = "RequireManagerRole")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        await _mediator.Send(new DeleteUserCommand(id));
        return RedirectToAction("GetAllUsers");
    }
}