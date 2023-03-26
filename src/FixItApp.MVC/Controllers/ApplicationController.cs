using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FixItApp.MVC.Controllers;

public class ApplicationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ApplicationController(IMediator mediator) => _mediator = mediator;
    
    
    public async Task<IActionResult> CreateApplication()
    {
        var applicationDto = new ApplicationDTO
        {
            Title = "Application3",
            Description = "Description3",
            ClientLogin = "zina",
            MasterLogin = "hammer"
        };

        var command = new CreateApplicationCommand(applicationDto);
        var result = new ApplicationDTO();
            
        try
        {
            result = await _mediator.Send(command);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return Ok(result);
    }

    public async Task<IActionResult> GetAllApplications()
    {
        var query = new GetAllApplicationsQuery();
        var result = new List<ApplicationDTO>();
            
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