using Npgsql;
using TicketSystem.Database;

namespace TicketSystem.Ticket;

class TicketService : TicketInterface
{
    async public Task<string?> Create(CreateTicketModel data)
    {
        try
        {
            var connection = await DatabaseService.OpenConnection();

            var cmd = new NpgsqlCommand(TicketConstants.CREATE, connection)
            {
                Parameters = {
                    new() { Value = data.amount },
                    new() { Value = TicketUtils.ValidateParameter(data.title) },
                    new() { Value = TicketUtils.ValidateParameter(data.price) },
                    new() { Value = TicketUtils.ValidateParameter(data.description) }
                },
            };

            var result = await cmd.ExecuteScalarAsync();
            connection?.Close();

            return result?.ToString();
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
            var connection = await DatabaseService.OpenConnection();

            var cmd = new NpgsqlCommand(TicketConstants.GET_ONE_BY_ID, connection);
            cmd.Parameters.AddWithValue(Guid.Parse(ID));

            var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();
            var ticket = TicketUtils.ReaderToTicketModel(reader);
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
            var connection = await DatabaseService.OpenConnection();

            var cmd = new NpgsqlCommand(TicketConstants.GET_ALL, connection);
            var reader = await cmd.ExecuteReaderAsync();

            var returnValue = new List<TicketModel> { };

            while (await reader.ReadAsync())
            {
                returnValue.Add(TicketUtils.ReaderToTicketModel(reader));
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
            var connection = await DatabaseService.OpenConnection();

            var cmd = new NpgsqlCommand(TicketConstants.UPDATE_ONE_BY_ID, connection)
            {
                Parameters = {
                    new() { Value = TicketUtils.ValidateParameter(data.title) },
                    new() { Value = TicketUtils.ValidateParameter(data.price) },
                    new() { Value = data.amount },
                    new() { Value = TicketUtils.ValidateParameter(data.description) },
                    new() { Value = DateTime.Now },
                    new() { Value = Guid.Parse(ID) },
                }
            };

            var result = await cmd.ExecuteScalarAsync();
            connection?.Close();

            return result?.ToString();
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
            var connection = await DatabaseService.OpenConnection();

            var cmd = new NpgsqlCommand(TicketConstants.DELETE_ONE_BY_ID, connection);
            cmd.Parameters.AddWithValue(Guid.Parse(ID));

            var result = await cmd.ExecuteScalarAsync();
            connection?.Close();

            return result?.ToString();
        }
        catch
        {
            return null;
        }
    }
}