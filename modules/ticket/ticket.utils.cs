using Npgsql;
namespace TicketSystem.Ticket;

public static class TicketUtils
{
    public static TicketModel ReaderToTicketModel(NpgsqlDataReader reader)
    {
        return new TicketModel
        {
            id = reader.GetGuid(0).ToString(),
            created_at = reader.GetDateTime(1),
            amount = reader.GetInt32(2),
            title = reader.GetString(3),
            price = reader.GetInt32(4),
            description = reader.GetString(5)
        };
    }
}