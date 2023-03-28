using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FixItApp.MVC.Controllers;

[Controller]
[Route("[controller]")]
public class ApplicationController : Controller
{
    private readonly IMediator _mediator;

    public ApplicationController(IMediator mediator) => _mediator = mediator;
    
    public async Task<IActionResult> CreateApplication()
    {
        var applicationDto = new ApplicationDTO
        {
            Title = "Application3",
            Description = "Description3",
            ClientLogin = "misha",
            MasterLogin = "checo"
        };
        await _mediator.Send(new CreateApplicationCommand(applicationDto));
        return RedirectToAction("GetAllApplications");
    }

    [HttpGet("GetAllApplications")]
    public async Task<IActionResult> GetAllApplications()
    {
        List<ApplicationExtendedDTO> result = await _mediator.Send(new GetAllApplicationsQuery());
        return View("Applications", result);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteApplication(string id)
    {
        await _mediator.Send(new DeleteApplicationCommand(id));
        return RedirectToAction("GetAllApplications");
    }

}