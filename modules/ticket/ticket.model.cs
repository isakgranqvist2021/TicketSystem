using System.ComponentModel.DataAnnotations;
namespace TicketSystem.Ticket;

public class TicketModel
{
    public string id { get; set; } = "";

    public DateTime created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public long amount { get; set; } = 0;

    public string? title { get; set; } = null;

    public long? price { get; set; } = null;

    public string? description { get; set; } = null;
}

public class CreateTicketModel
{
    public long amount { get; set; } = 0;

    public string? title { get; set; } = null;

    public long? price { get; set; } = null;

    public string? description { get; set; } = null;
}

public class UpdateTicketModel
{
    public string? title { get; set; } = null;

    public long amount { get; set; } = 0;

    public long? price { get; set; } = null;

    public string? description { get; set; } = null;
}
