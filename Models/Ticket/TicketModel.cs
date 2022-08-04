namespace TicketSystem.Models.Ticket;

class TicketModel
{
    public string ID { get; set; } = "";
    public string? TITLE { get; set; }
}

class CreateTicketModel
{
    public string TITLE { get; set; } = "";
}

class UpdateTicketModel
{
    public string? TITLE { get; set; }
}