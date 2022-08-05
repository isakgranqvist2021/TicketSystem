using Npgsql;

namespace TicketSystem.Database;

public static class DatabaseService
{
    public static async Task<NpgsqlConnection?> OpenConnection()
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