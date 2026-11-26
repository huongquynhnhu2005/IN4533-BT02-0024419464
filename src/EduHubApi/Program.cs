using EduHubApi.Data;
using EduHubApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Host=localhost;Port=5432;Database=eduhub;Username=postgres;Password=YOUR_PASSWORD";
builder.Services.AddSingleton(Db.CreateDataSource(connectionString));

var app = builder.Build();

app.MapRegistrationEndpoints();

app.Run();