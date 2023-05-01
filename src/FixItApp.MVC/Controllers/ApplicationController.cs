using System.Security.Claims;
using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixItApp.MVC.Controllers;

public class ApplicationController : Controller
{
    private readonly IMediator _mediator;

    public ApplicationController(IMediator mediator) => _mediator = mediator;


    [HttpGet("[controller]/CreateApplication")]
    [Authorize]
    public IActionResult CreateApplication()
    {
        var id  = User.Claims.FirstOrDefault(c => c.Type == "UserId");
        return View("CreateApp", new ApplicationDTO { ClientId = id.Value });
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PostApplication(ApplicationDTO applicationDto)
    {
        await _mediator.Send(new CreateApplicationCommand(applicationDto));
        if(User.Claims.FirstOrDefault(c => c.Type =="Role").Value == "Manager")
            return RedirectToAction("GetAllApplications");
        
        return RedirectToAction("Index", "Home");  //change to get my applications
    }

    [HttpGet("[controller]/GetAllApplications")]
    [Authorize(Policy = "RequireManagerRole")]
    public async Task<IActionResult> GetAllApplications()
    {
        List<ApplicationExtendedDTO> result = await _mediator.Send(new GetAllApplicationsQuery());
        return View("Applications", result);
    }

    [HttpPost]
    [Authorize(Policy = "RequireManagerRole")]
    public async Task<IActionResult> DeleteApplication(string id)
    {
        await _mediator.Send(new DeleteApplicationCommand(id));
        return RedirectToAction("GetAllApplications");
    }

    [HttpGet("[controller]/EditApplication/")] //??????
    [Authorize(Policy = "RequireManagerRole")]
    public async Task<IActionResult> EditApplication(string id, CancellationToken token)
    {
        var application = await _mediator.Send(new GetApplicationByIdQuery(id), token);
        return View("EditApplication", application);
    }
    
    [HttpPost] 
    [Authorize(Policy = "RequireManagerRole")]
    public async Task<IActionResult> PutApplication(ApplicationExtendedDTO appDto, CancellationToken token)
    {
        await _mediator.Send(new EditApplicationCommand(appDto), token);
        return RedirectToAction("GetAllApplications");
    }
}