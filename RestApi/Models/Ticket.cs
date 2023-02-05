namespace RestApi.Models;

public class Ticket 
{
    public Guid Id { get;  }
    public string Username { get;  }
    public string Email { get; set; }
    public string Description { get;  }
    public DateTime SubmitDate { get; }
    public List<string> Tags { get;  }

    public Ticket(
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

