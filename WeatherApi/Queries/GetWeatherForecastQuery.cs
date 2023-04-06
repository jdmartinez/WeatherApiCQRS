using MediatR;

namespace WeatherApi.Queries;

public class GetWeatherForecastQuery : IRequest<WeatherForecast>
{
    public DateOnly Date { get; set; }
}
