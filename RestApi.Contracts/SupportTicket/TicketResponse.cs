using System;
using System.Collections.Generic;

namespace RestApi.Contracts.SupportTicket;

public record TicketResponse(
    Guid Id,
    string Username,
    string Email,
    string Description,
    DateTime SubmitDate,
    List<string> Tags
) {}