using Microsoft.AspNetCore.Mvc;
using RestApi.Contracts.SupportTicket;
using RestApi.Models;

namespace RestApi.Controllers;

[ApiController]
[Route("tickets")]
public class SupportTicketController : ControllerBase 
{
    [HttpPost]
    public IActionResult CreateTicket(CreateTicketRequest request) 
    {
        var ticket = new SupportTicket(
            Guid.NewGuid(),
            request.Username,
            request.Email,
            request.Description,
            DateTime.UtcNow,
            request.Tags
        );

        var response = new TicketResponse(
            ticket.Id,
            ticket.Username,
            ticket.Email,
            ticket.Description,
            ticket.SubmitDate,
            ticket.Tags
        );
        
        return CreatedAtAction(
            nameof(ReturnTicket),
            new { id = ticket.Id },
            response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult ReturnTicket(Guid id) 
    {
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertTicket(Guid id, UpsertTicketRequest request) 
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteTicket(Guid id) 
    {
        return Ok(id);
    }
}