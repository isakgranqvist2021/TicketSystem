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

        var cmd = new NpgsqlCommand("INSERT INTO ticket (TITLE) VALUES (@TITLE)", conn);
        cmd.Parameters.AddWithValue("TITLE", data.TITLE);
        await cmd.ExecuteNonQueryAsync();

        return "OK";
    }

    public TicketModel GetOneById(string ID)
    {
        return new TicketModel { };
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

    public bool UpdateOneById(string ID, UpdateTicketModel data)
    {
        return true;
    }

    public bool DeleteOneById(string ID)
    {
        return true;
    }
}