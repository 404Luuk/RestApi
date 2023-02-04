using Microsoft.AspNetCore.Mvc;
using RestApi.Contracts.SupportTicket;

namespace RestApi.Controllers;

[ApiController]
public class SupportTicketController : ControllerBase 
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

    [HttpPut("/tickets/{id:guid}")]
    public IActionResult UpsertTicket(Guid id, UpsertTicketRequest request) 
    {
        return Ok(request);
    }

    [HttpDelete("/tickets/{id:guid}")]
    public IActionResult DeleteTicket(Guid id) 
    {
        return Ok(id);
    }
}