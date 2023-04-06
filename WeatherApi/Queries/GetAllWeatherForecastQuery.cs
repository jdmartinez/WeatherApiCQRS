using MediatR;

namespace WeatherApi.Queries;

public class GetAllWeatherForecastQuery : IRequest<List<WeatherForecast>>
{
    public int Days { get; set; }
}
