using System.Runtime.CompilerServices;

namespace WeatherApi.Application;

public static class WeatherForecastRetriever
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching"
    };

    public static async IAsyncEnumerable<WeatherForecast> GetForecastAsync(
        int maxDays = 1,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var forecast = AsyncEnumerable.Range(0, maxDays)
            .Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });

        await foreach (var f in forecast)
        {
            yield return f;
        }
    }
}
