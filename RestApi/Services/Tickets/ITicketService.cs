using RestApi.Models;

namespace RestApi.Services.Tickets;

public interface ITicketService 
{
    void CreateTicket(SupportTicket ticket);
    void DeleteTicket(Guid id);
    SupportTicket GetTicket(Guid id);
    void UpsertTicket(SupportTicket ticket);
}