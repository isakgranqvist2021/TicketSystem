using TicketSystem.Models.Ticket;
namespace TicketSystem.Interfaces.Ticket;

interface TicketInterface
{
    public Task<string?> Create(CreateTicketModel data);
    public Task<TicketModel?> GetOneById(string ID);
    public Task<List<TicketModel>?> GetAll();
    public Task<string?> UpdateOneById(string ID, UpdateTicketModel data);
    public Task<string?> DeleteOneById(string ID);
};
