using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixItApp.MVC.Controllers;

public class FeedbackController : Controller
{
    private readonly IMediator _mediator;
    
    public FeedbackController(IMediator mediator) 
        => _mediator = mediator;

    
    [HttpGet("[controller]/CreateFeedback")]
    [Authorize(Policy = "RequireCustomerRole")]
    public async Task<IActionResult> CreateFeedback(string appId)
    {
        return View("CreateFeedback", new FeedbackDTO{AppId = appId});
    }

    [HttpPost]
    [Authorize(Policy = "RequireCustomerRole")]
    public async Task<IActionResult> PostFeedBack(FeedbackDTO feedback)
    {
        await _mediator.Send(new CreateFeedBackCommand(feedback));
        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet("[controller]/GetAllFeedBacks")]
    public async Task<IActionResult> GetAllFeedBacks()
    {
        var result = await _mediator.Send(new GetAllFeedbacksQuery());
        return View("Feedbacks", result);
    }
}