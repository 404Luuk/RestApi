using System;
using System.Collections.Generic;

namespace RestApi.Contracts.Ticket;

public record UpsertTicketRequest(
    string Username,
    string Email,
    string Description,
    DateTime SubmitDate,
    DateTime EditDate,
    List<string> Tags
) {}