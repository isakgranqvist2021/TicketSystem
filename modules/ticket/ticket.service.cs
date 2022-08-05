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

            var cmd = new NpgsqlCommand("INSERT INTO ticket (TITLE) VALUES ($1) RETURNING ID", connection);
            cmd.Parameters.AddWithValue(data.TITLE ?? "");
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

            var cmd = new NpgsqlCommand("SELECT * FROM ticket WHERE ID = $1", connection);
            cmd.Parameters.AddWithValue(Guid.Parse(ID));

            var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();

            connection?.Close();
            return new TicketModel
            {
                ID = reader.GetGuid(0).ToString(),
                TITLE = reader.GetString(1),
            };
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
                returnValue.Add(new TicketModel
                {
                    ID = reader.GetGuid(0).ToString(),
                    TITLE = reader.GetString(1),
                });
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

            var cmd = new NpgsqlCommand("UPDATE ticket SET TITLE = $1 WHERE ID = $2", connection);
            cmd.Parameters.AddWithValue(data.TITLE ?? "");
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

            var cmd = new NpgsqlCommand("DELETE FROM ticket WHERE ID = $1", connection);
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