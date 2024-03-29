using ErrorOr;
using RestApi.Models;
using RestApi.ServiceErrors;

namespace RestApi.Services.Tickets;

public class TicketService : ITicketService
{
    //TODO: Link database && reWrite service
    private static readonly Dictionary<Guid, Ticket> _tickets = new();
    public void CreateTicket(Ticket ticket)
    {
        _tickets.Add(ticket.Id, ticket);
    }

    public void DeleteTicket(Guid id)
    {
        _tickets.Remove(id);
    }

    public ErrorOr<Ticket> GetTicket(Guid id)
    {
        if(_tickets.TryGetValue(id, out var ticket)) { return ticket; }
        return Errors.Ticket.NotFound;
    }

    public void UpsertTicket(Ticket ticket)
    {
        _tickets[ticket.Id] = ticket;
    }
}
