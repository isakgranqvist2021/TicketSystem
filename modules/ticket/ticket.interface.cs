namespace TicketSystem.Ticket;

interface TicketInterface
{
    public int? Create(CreateTicketModel data);
    public TicketModel? GetOneById(int ID);
    public IEnumerable<TicketModel>? GetAll();
    public int? UpdateOneById(int ID, UpdateTicketModel data);
    public int? DeleteOneById(int ID);
};
