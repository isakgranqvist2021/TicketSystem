using TicketSystem.Models.Ticket;

namespace TicketSystem.Interfaces.Ticket;

interface TicketInterface
{
    public string Create(CreateTicketModel data);
    public TicketModel GetOneById(int ticketId);
    public List<TicketModel> GetAll();
    public bool UpdateOneById(int ticketId, UpdateTicketModel data);
    public bool DeleteOneById(int ticketId);
};
