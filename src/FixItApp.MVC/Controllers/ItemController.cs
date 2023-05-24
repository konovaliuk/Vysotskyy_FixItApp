using FixItApp.ApplicationCore.Commands;
using FixItApp.ApplicationCore.Queries;
using FixItApp.Infrastructure.DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixItApp.MVC.Controllers;

[Controller]
[Route("[controller]")]
public class ItemController : Controller
{
    private readonly IMediator _mediator;
    private static string _applicationId = string.Empty;

    public ItemController(IMediator mediator) => _mediator = mediator;

    [HttpGet("GetItemsApplication/{id?}")]
    [Authorize]
    public async Task<IActionResult> GetItemsApplication(string id, CancellationToken token)
    {
        List<ItemDTO> listDTO = await _mediator.Send(new GetItemsByIdQuery(id), token);
        _applicationId = id;
        
        if (listDTO.Count == 0)
            listDTO.Add(new ItemDTO{ApplicationId = id});
        
        return View("Items", listDTO);
    }

    [HttpGet("CreateItem/{id?}")]
    [Authorize(Policy = "RequireCustomerRole")]
    public IActionResult CreateItem(string applicationId)
    {
        return View("CreateItem", new ItemDTO{ApplicationId = applicationId});
    }
    
    [HttpPost("AddItem")]
    [Authorize(Policy = "RequireCustomerRole")]
    public async Task<IActionResult> AddItem(ItemDTO dto, CancellationToken token)
    {
        await _mediator.Send(new CreateItemCommand(dto), token);
        return RedirectToAction("GetItemsApplication", "Item",
            new {id = _applicationId});
    }

    [HttpPost("DeleteItem/{id?}")]
    [Authorize(Policy = "RequireCustomerRole")]
    public async Task<IActionResult> DeleteItem(string id, CancellationToken token)
    {
        await _mediator.Send(new DeleteItemCommand(id), token);
        return RedirectToAction("GetItemsApplication", "Item",
            new {id = _applicationId});
    }
    
}