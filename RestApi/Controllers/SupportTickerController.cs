using Microsoft.AspNetCore.Mvc;
using RestApi.Contracts.SupportTicket;
using RestApi.Models;
using RestApi.Services.Tickets;

namespace RestApi.Controllers;

[ApiController]
[Route("tickets")]
public class SupportTicketController : ControllerBase 
{
    private readonly ITicketService _ticketService;

    public SupportTicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

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

        _ticketService.CreateTicket(ticket);

        var response = new TicketResponse(
            ticket.Id,
            ticket.Username,
            ticket.Email,
            ticket.Description,
            ticket.SubmitDate,
            ticket.Tags
        );

        return CreatedAtAction(
            actionName: nameof(ReturnTicket),
            routeValues: new { id = ticket.Id },
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult ReturnTicket(Guid id) 
    {
        SupportTicket ticket = _ticketService.GetTicket(id);

        var response = new TicketResponse(
            ticket.Id,
            ticket.Username,
            ticket.Email,
            ticket.Description,
            ticket.SubmitDate,
            ticket.Tags
        );

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertTicket(Guid id, UpsertTicketRequest request) 
    {
            var ticket = new SupportTicket(
            id,
            request.Username,
            request.Email,
            request.Description,
            request.SubmitDate,
            request.Tags
        );
        _ticketService.UpsertTicket(ticket);

        //return 201 if req == new
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteTicket(Guid id) 
    {
        _ticketService.DeleteTicket(id);
        return NoContent();
    }
}