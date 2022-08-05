using Npgsql;
using TicketSystem.Models.Ticket;
using TicketSystem.Interfaces.Ticket;
using TicketSystem.Services.Database;

namespace TicketSystem.Services.Ticket;

class TicketService : TicketInterface
{

    private DatabaseService _databaseService = new DatabaseService();

    async public Task<string> Create(CreateTicketModel data)
    {
        var conn = await _databaseService.OpenConnection();

        var cmd = new NpgsqlCommand("INSERT INTO ticket (TITLE) VALUES ($1)", conn);
        cmd.Parameters.AddWithValue(data.TITLE ?? "");
        await cmd.ExecuteNonQueryAsync();

        return "OK";
    }

    async public Task<TicketModel> GetOneById(string ID)
    {
        var conn = await _databaseService.OpenConnection();

        var cmd = new NpgsqlCommand("SELECT * FROM ticket WHERE ID = $1", conn);
        cmd.Parameters.AddWithValue(Guid.Parse(ID));

        var reader = await cmd.ExecuteReaderAsync();
        await reader.ReadAsync();

        return new TicketModel
        {
            ID = reader.GetGuid(0).ToString(),
            TITLE = reader.GetString(1),
        };
    }

    async public Task<List<TicketModel>> GetAll()
    {
        var returnValue = new List<TicketModel> { };
        var conn = await _databaseService.OpenConnection();

        var cmd = new NpgsqlCommand("SELECT * FROM ticket", conn);
        var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            returnValue.Add(new TicketModel
            {
                ID = reader.GetGuid(0).ToString(),
                TITLE = reader.GetString(1),
            });
        }

        return returnValue;
    }

    async public Task<bool> UpdateOneById(string ID, UpdateTicketModel data)
    {
        var conn = await _databaseService.OpenConnection();

        var cmd = new NpgsqlCommand("UPDATE ticket SET TITLE = $1 WHERE ID = $2", conn);
        cmd.Parameters.AddWithValue(data.TITLE ?? "");
        cmd.Parameters.AddWithValue(Guid.Parse(ID));
        await cmd.ExecuteNonQueryAsync();

        return true;
    }

    async public Task<bool> DeleteOneById(string ID)
    {
        var conn = await _databaseService.OpenConnection();

        var cmd = new NpgsqlCommand("DELETE FROM ticket WHERE ID = $1", conn);
        cmd.Parameters.AddWithValue(Guid.Parse(ID));
        await cmd.ExecuteNonQueryAsync();

        return true;
    }
}