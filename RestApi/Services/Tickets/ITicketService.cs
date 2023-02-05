using RestApi.Models;

namespace RestApi.Services.Tickets;

public interface ITicketService 
{
    void CreateTicket(Ticket ticket);
    void DeleteTicket(Guid id);
    Ticket GetTicket(Guid id);
    void UpsertTicket(Ticket ticket);
}