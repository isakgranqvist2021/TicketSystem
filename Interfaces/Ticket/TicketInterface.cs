using TicketSystem.Models.Ticket;

namespace TicketSystem.Interfaces.Ticket;

interface TicketInterface
{
    public Task<string> Create(CreateTicketModel data);
    public TicketModel GetOneById(string ID);
    public Task<List<TicketModel>> GetAll();
    public bool UpdateOneById(string ID, UpdateTicketModel data);
    public bool DeleteOneById(string ID);
};
