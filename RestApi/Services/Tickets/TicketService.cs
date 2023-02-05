using RestApi.Models;

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

    public Ticket GetTicket(Guid id)
    {
        return _tickets[id];
    }

    public void UpsertTicket(Ticket ticket)
    {
        _tickets[ticket.Id] = ticket;
    }
}
