using BloodDonationDatabase.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddInfrastructure(configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();


