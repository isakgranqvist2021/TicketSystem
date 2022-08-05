using Npgsql;

namespace TicketSystem.Database;

public class DatabaseService : DatabaseInterface
{
    public async Task<NpgsqlConnection?> OpenConnection()
    {
        try
        {
            var connString = Environment.GetEnvironmentVariable("PSQL_CONNECTION_STRING");

            var connection = new NpgsqlConnection(connString);
            await connection.OpenAsync();

            return connection;
        }
        catch
        {
            return null;
        }
    }
}