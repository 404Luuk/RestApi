using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using RestApi.Contracts.Ticket;
using RestApi.Models;
using RestApi.ServiceErrors;
using RestApi.Services.Tickets;

namespace RestApi.Controllers;

[Route("/tickets")]
public class TicketController : ApiController 
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpPost]
    public IActionResult CreateTicket(CreateTicketRequest request) 
    {
        var ticket = new Ticket(
            Guid.NewGuid(),
            request.Username,
            request.Email,
            request.Description,
            DateTime.UtcNow,
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
            ticket.EditDate,
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
        ErrorOr<Ticket> getTicketResult = _ticketService.GetTicket(id);

        return getTicketResult.Match(
            ticket => Ok(MapTicketResponse(ticket)),
            errors => Problem(errors));
    }

    private static TicketResponse MapTicketResponse(Ticket ticket)
    {
        return new TicketResponse(
            ticket.Id,
            ticket.Username,
            ticket.Email,
            ticket.Description,
            ticket.SubmitDate,
            ticket.EditDate,
            ticket.Tags
        );
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertTicket(Guid id, UpsertTicketRequest request) 
    {
            var ticket = new Ticket(
            id,
            request.Username,
            request.Email,
            request.Description,
            request.SubmitDate,
            DateTime.UtcNow,
            request.Tags
        );
        _ticketService.UpsertTicket(ticket);

        //todo return 201 if req == new
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteTicket(Guid id) 
    {
        _ticketService.DeleteTicket(id);
        return NoContent();
    }
}