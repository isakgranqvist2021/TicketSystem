using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var connString = Environment.GetEnvironmentVariable("PSQL_CONNECTION_STRING");
await using var conn = new NpgsqlConnection(connString);
await conn.OpenAsync();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
