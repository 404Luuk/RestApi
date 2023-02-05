using ErrorOr;
using RestApi.Models;

namespace RestApi.Services.Tickets;

public interface ITicketService 
{
    void CreateTicket(Ticket ticket);
    ErrorOr<Ticket> GetTicket(Guid id);
    void UpsertTicket(Ticket ticket);
    void DeleteTicket(Guid id);
}