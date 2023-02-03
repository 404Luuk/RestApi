using Microsoft.AspNetCore.Mvc;
using RestApi.Contracts.SupportTicket;

namespace RestApi.Controllers;

[ApiController]
public class TicketController : ControllerBase 
{
    [HttpPost("/tickets")]
    public IActionResult CreateTicket(CreateTicketRequest request) 
    {
        return Ok(request);
    }

    [HttpGet("/tickets/{id:guid}")]
    public IActionResult ReturnTicket(Guid id) 
    {
        return Ok(id);
    }

}