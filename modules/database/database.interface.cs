using Npgsql;

namespace TicketSystem.Database;

interface DatabaseInterface
{
    public Task<NpgsqlConnection?> OpenConnection();
};
