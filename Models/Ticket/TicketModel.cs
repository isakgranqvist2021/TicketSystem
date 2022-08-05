using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models.Ticket;

public class TicketModel
{
    [Required]
    public string ID { get; set; } = "";

    [Required]
    public string? TITLE { get; set; } = null;
}

public class CreateTicketModel
{
    [Required]
    public string? TITLE { get; set; } = null;
}

public class UpdateTicketModel
{
    [Required]
    public string? TITLE { get; set; } = null;
}