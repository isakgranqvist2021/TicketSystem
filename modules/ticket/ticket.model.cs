using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Ticket;

public class TicketModel
{
    public string id { get; set; } = "";

    public DateTime created_at { get; set; }

    public long amount { get; set; }

    public string title { get; set; } = "";

    public long price { get; set; }

    public string description { get; set; } = "";
}

public class CreateTicketModel
{
    [Required]
    public long amount { get; set; }

    [Required]
    public string title { get; set; } = "";

    [Required]
    public long price { get; set; }

    [Required]
    public string description { get; set; } = "";
}

public class UpdateTicketModel
{
    [Required]
    public string title { get; set; } = "";

    [Required]
    public long amount { get; set; }

    [Required]
    public long price { get; set; }

    [Required]
    public string description { get; set; } = "";
}
