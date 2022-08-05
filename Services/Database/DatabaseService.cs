using Npgsql;
using TicketSystem.Interfaces.Database;

namespace TicketSystem.Services.Database;

public class DatabaseService : DatabaseInterface
{
    public async Task<NpgsqlConnection> OpenConnection()
    {
        var connString = Environment.GetEnvironmentVariable("PSQL_CONNECTION_STRING");

        var connection = new NpgsqlConnection(connString);
        await connection.OpenAsync();

        return connection;
    }
}