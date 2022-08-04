using TicketSystem.Models.Ticket;
using TicketSystem.Interfaces.Ticket;

namespace TicketSystem.Services.Ticket;

class TicketService : TicketInterface
{

    public string Create(CreateTicketModel data)
    {
        return "";
    }

    public TicketModel GetOneById(int ticketId)
    {
        return new TicketModel { };
    }

    public List<TicketModel> GetAll()
    {
        return new List<TicketModel> { };
    }

    public bool UpdateOneById(int ticketId, UpdateTicketModel data)
    {
        return true;
    }

    public bool DeleteOneById(int ticketId)
    {
        return true;
    }
}