using TicketSystem.Database;
using SqlKata.Execution;

namespace TicketSystem.Ticket;

class TicketService : TicketInterface
{
    public int? Create(CreateTicketModel data)
    {
        var db = DatabaseService.OpenConnection();
        return db?.Query("ticket").InsertGetId<int>(new
        {
            amount = data.amount,
            title = data.title,
            price = data.price,
            description = data.description,
        });
    }

    public TicketModel? GetOneById(int ID)
    {
        var db = DatabaseService.OpenConnection();
        return db?.Query("ticket").Select("*").Where("id", ID).First<TicketModel>();
    }

    public IEnumerable<TicketModel>? GetAll()
    {
        var db = DatabaseService.OpenConnection();
        return db?.Query("ticket").Select("*").Get<TicketModel>();
    }

    public int? UpdateOneById(int ID, UpdateTicketModel data)
    {
        var ticket = GetOneById(ID);
        var db = DatabaseService.OpenConnection();
        return db?.Query("ticket").Where("id", ID).Update(new
        {
            amount = data.amount,
            title = data.title ?? ticket?.title,
            price = data.price ?? ticket?.price,
            description = data.description ?? ticket?.description,
            updated_at = DateTime.UtcNow,
        });
    }

    public int? DeleteOneById(int ID)
    {
        var db = DatabaseService.OpenConnection();
        return db?.Query("ticket").Where("id", ID).Delete();
    }
}