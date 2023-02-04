using RestApi.Models;

namespace RestApi.Services.Tickets;

public class TicketService : ITicketService
{
    //TODO: Link database && reWrite service
    private static readonly Dictionary<Guid, SupportTicket> _tickets = new();
    public void CreateTicket(SupportTicket ticket)
    {
        _tickets.Add(ticket.Id, ticket);
    }

    public void DeleteTicket(Guid id)
    {
        _tickets.Remove(id);
    }

    public SupportTicket GetTicket(Guid id)
    {
        return _tickets[id];
    }

    public void UpsertTicket(SupportTicket ticket)
    {
        _tickets[ticket.Id] = ticket;
    }
}
