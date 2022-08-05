using TicketSystem.Models.Ticket;
namespace TicketSystem.Interfaces.Ticket;

interface TicketInterface
{
    public Task Create(CreateTicketModel data);
    public Task<TicketModel> GetOneById(string ID);
    public Task<List<TicketModel>> GetAll();
    public Task UpdateOneById(string ID, UpdateTicketModel data);
    public Task DeleteOneById(string ID);
};
