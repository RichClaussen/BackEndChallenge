var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.AddSqlServerDbContext<CrmDataContext>("crmdatabase");

var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new Forecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapDefaultEndpoints();

app.Run();
