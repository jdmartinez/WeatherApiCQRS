using FluentValidation;

using MediatR;

using WeatherApi.Application;
using WeatherApi.Queries;
using WeatherApi.Validators;

namespace WeatherApi.Handlers;

public class GetAllWeatherForecastQueryHandler : IRequestHandler<GetAllWeatherForecastQuery, List<WeatherForecast>>
{
    private readonly IValidator<GetAllWeatherForecastQuery> _validator;

    public GetAllWeatherForecastQueryHandler(IValidator<GetAllWeatherForecastQuery> validator)
    {
        _validator = validator;
    }

    public async Task<List<WeatherForecast>> Handle(GetAllWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(request);

        return await WeatherForecastRetriever.GetForecastAsync(request.Days, cancellationToken)
            .ToListAsync(cancellationToken);
    }
}
