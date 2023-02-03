using System;
using System.Collections.Generic;

namespace RestApi.Contracts.SupportTicket;

public record CreateTicketRequest(
    string Username,
    string Email,
    string Description,
    DateTime SubmitDate,
    List<string> Tags
) {}