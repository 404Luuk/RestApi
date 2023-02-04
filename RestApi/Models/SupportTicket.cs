namespace RestApi.Models;

public class SupportTicket 
{
    public Guid Id { get;  }
    public string Username { get;  }
    public string Email { get; set; }
    public string Description { get;  }
    public DateTime SubmitDate { get; }
    public List<string> Tags { get;  }

    public SupportTicket(
        Guid id, 
        string username,
        string email,
        string description,
        DateTime submitDate,
        List<string> tags
    ) 
    {
        Id = id;
        Username = username;
        Email = email;
        Description = description;
        SubmitDate = submitDate;
        Tags = tags;
    }
}

