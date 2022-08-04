using Npgsql;

namespace TicketSystem.Interfaces.Database;

interface DatabaseInterface
{
    public Task<NpgsqlConnection> OpenConnection();
};
