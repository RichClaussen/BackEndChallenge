namespace ChellengeAspireApp.Web;

public class WeatherApiClient(HttpClient httpClient)
{
    public async Task<WeatherForecast[]> GetWeatherAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<WeatherForecast>? forecasts = null;

        await foreach (var forecast in httpClient.GetFromJsonAsAsyncEnumerable<WeatherForecast>("/weatherforecast", cancellationToken))
        {
            if (forecasts?.Count >= maxItems)
            {
                break;
            }
            if (forecast is not null)
            {
                forecasts ??= [];
                forecasts.Add(forecast);
            }
        }

        return forecasts?.ToArray() ?? [];
    }

    public async Task<Customer[]> GetCustomersAsync(CancellationToken cancellationToken = default)
    {
        List<Customer>? customers = null;

        await foreach(var customer in httpClient.GetFromJsonAsAsyncEnumerable<Customer>("/customers", cancellationToken))
        {
            if (customer is not null)
            {
                customers ??= [];
                customers.Add(customer);
            }
        }

        return customers?.ToArray() ?? [];
    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public record Customer(Guid Id, string FirstName, string MiddleName, string LastName, string Email, string Phone)
{
}
