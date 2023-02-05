using ErrorOr;

namespace RestApi.ServiceErrors;

public static class Errors 
{
    public static class Ticket
    {
        public static Error NotFound => Error.NotFound(
            code: "Ticket.NotFound",
            description: "No matching ticket found"
        );
    }   
}