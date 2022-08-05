namespace TicketSystem.Ticket;

public static class TicketConstants
{
    public static string CREATE = @"
        INSERT INTO ticket (amount, title, price, description) 
        VALUES ($1, $2, $3, $4)
        RETURNING id
    ";

    public static string GET_ONE_BY_ID = "SELECT * FROM ticket WHERE id = $1";
    public static string GET_ALL = "SELECT * FROM ticket";

    public static string UPDATE_ONE_BY_ID = @"
        UPDATE ticket SET title = $1, price = $2, amount = $3, description = $4, updated_at = $5 
        WHERE id = $6
    ";

    public static string DELETE_ONE_BY_ID = "DELETE FROM ticket WHERE id = $1";
}