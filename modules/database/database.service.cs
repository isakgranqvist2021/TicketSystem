using Npgsql;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace TicketSystem.Database;

public static class DatabaseService
{
    public static QueryFactory? OpenConnection()
    {
        var uri = Environment.GetEnvironmentVariable("PSQL_CONNECTION_STRING");

        var connection = new NpgsqlConnection(uri);
        var compiler = new PostgresCompiler();

        return new QueryFactory(connection, compiler);
    }
}