using Npgsql;

namespace TicketSystem.Ticket;

public static class TicketUtils
{
    public static TicketModel ReaderToTicketModel(NpgsqlDataReader reader)
    {

        DateTime? updated_at = null;

        if (!reader.IsDBNull(2))
        {
            updated_at = reader.GetDateTime(2);
        }

        return new TicketModel
        {
            id = reader.GetGuid(0).ToString(),
            created_at = reader.GetDateTime(1),
            updated_at = updated_at,
            amount = reader.GetInt64(3),
            title = reader.GetString(4),
            price = reader.GetInt64(5),
            description = reader.GetString(6)
        };
    }
}