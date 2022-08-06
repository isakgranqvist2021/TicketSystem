using Npgsql;

namespace TicketSystem.Ticket;

public static class TicketUtils
{
    public static TicketModel ReaderToTicketModel(NpgsqlDataReader reader)
    {
        var id = reader.GetGuid(0).ToString();
        var created_at = reader.GetDateTime(1);
        var amount = reader.GetInt64(3);

        DateTime? updated_at = null;
        if (!reader.IsDBNull(2))
        {
            updated_at = reader.GetDateTime(2);
        }


        string? title = null;
        if (!reader.IsDBNull(4))
        {
            title = reader.GetString(4);
        }

        long? price = null;
        if (!reader.IsDBNull(5))
        {
            price = reader.GetInt64(5);
        }

        string? description = null;
        if (!reader.IsDBNull(6))
        {
            description = reader.GetString(6);
        }

        return new TicketModel
        {
            id = id,
            created_at = created_at,
            updated_at = updated_at,
            amount = amount,
            title = title,
            price = price,
            description = description
        };
    }

    public static Object ValidateParameter(Object? value)
    {
        if (value == null)
        {
            return DBNull.Value;
        }

        return value;
    }
}