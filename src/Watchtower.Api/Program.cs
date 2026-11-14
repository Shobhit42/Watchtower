using Watchtower.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Postgres")
    ?? throw new InvalidOperationException("Connection string 'Postgres' is missing.");

builder.Services.AddInfrastructure(connectionString);

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();