using Npgsql;
using TicketSystem.Database;

namespace TicketSystem.Ticket;

class TicketService : TicketInterface
{
    private DatabaseService _databaseService = new DatabaseService();

    async public Task<string?> Create(CreateTicketModel data)
    {
        try
        {
            var connection = await _databaseService.OpenConnection();

            var cmd = new NpgsqlCommand(
                "INSERT INTO ticket (amount, title, price, description) VALUES ($1, $2, $3, $4)",
                connection
            );

            cmd.Parameters.AddWithValue(data.amount);
            cmd.Parameters.AddWithValue(data.title ?? "");
            cmd.Parameters.AddWithValue(data.price);
            cmd.Parameters.AddWithValue(data.description);
            await cmd.ExecuteNonQueryAsync();

            connection?.Close();
            return "OK";
        }
        catch
        {
            return null;
        }
    }

    async public Task<TicketModel?> GetOneById(string ID)
    {
        try
        {
            var connection = await _databaseService.OpenConnection();

            var cmd = new NpgsqlCommand("SELECT * FROM ticket WHERE id = $1", connection);
            cmd.Parameters.AddWithValue(Guid.Parse(ID));

            var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();

            var ticket = new TicketModel
            {
                id = reader.GetGuid(0).ToString(),
                created_at = reader.GetDateTime(1),
                amount = reader.GetInt32(2),
                title = reader.GetString(3),
                price = reader.GetInt32(4),
                description = reader.GetString(5)
            };

            connection?.Close();

            return ticket;
        }
        catch
        {
            return null;
        }
    }

    async public Task<List<TicketModel>?> GetAll()
    {
        try
        {
            var connection = await _databaseService.OpenConnection();

            var cmd = new NpgsqlCommand("SELECT * FROM ticket", connection);
            var reader = await cmd.ExecuteReaderAsync();

            var returnValue = new List<TicketModel> { };
            while (await reader.ReadAsync())
            {
                var ticket = new TicketModel
                {
                    id = reader.GetGuid(0).ToString(),
                    created_at = reader.GetDateTime(1),
                    amount = reader.GetInt32(2),
                    title = reader.GetString(3),
                    price = reader.GetInt32(4),
                    description = reader.GetString(5)
                };

                returnValue.Add(ticket);
            }

            connection?.Close();
            return returnValue;
        }
        catch
        {
            return null;
        }
    }

    async public Task<string?> UpdateOneById(string ID, UpdateTicketModel data)
    {
        try
        {
            var connection = await _databaseService.OpenConnection();

            var cmd = new NpgsqlCommand(
                "UPDATE ticket SET title = $1, price = $2, amount = $3, description = $4 WHERE id = $5",
                connection
            );

            cmd.Parameters.AddWithValue(data.title);
            cmd.Parameters.AddWithValue(data.price);
            cmd.Parameters.AddWithValue(data.amount);
            cmd.Parameters.AddWithValue(data.description);
            cmd.Parameters.AddWithValue(Guid.Parse(ID));
            await cmd.ExecuteNonQueryAsync();

            connection?.Close();
            return ID;
        }
        catch
        {
            return null;
        }
    }

    async public Task<string?> DeleteOneById(string ID)
    {
        try
        {
            var connection = await _databaseService.OpenConnection();

            var cmd = new NpgsqlCommand("DELETE FROM ticket WHERE id = $1", connection);
            cmd.Parameters.AddWithValue(Guid.Parse(ID));
            await cmd.ExecuteNonQueryAsync();

            connection?.Close();
            return ID;
        }
        catch
        {
            return null;
        }
    }
}