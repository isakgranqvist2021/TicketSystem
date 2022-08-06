
namespace TicketSystem.Ticket;

public static class TicketUtils
{
    public static Object ValidateParameter(Object? value)
    {
        if (value == null)
        {
            return DBNull.Value;
        }

        return value;
    }
}