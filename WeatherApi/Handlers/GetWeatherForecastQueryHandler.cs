using System;
using System.Runtime.CompilerServices;

using FluentValidation;

using MediatR;

using WeatherApi.Application;
using WeatherApi.Queries;
using WeatherApi.Validators;

namespace WeatherApi.Handlers;

public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, WeatherForecast>
{
    private readonly IValidator<GetWeatherForecastQuery> _validator;

    public GetWeatherForecastQueryHandler(IValidator<GetWeatherForecastQuery> validator)
    {
        _validator = validator;
    }

    public async Task<WeatherForecast> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        var todayOnly = DateOnly.FromDateTime(DateTime.Now);
        
        _validator.ValidateAndThrow(request);        
        
        var days = (request.Date.DayNumber - todayOnly.DayNumber) + 1;

        return await WeatherForecastRetriever.GetForecastAsync(days, cancellationToken)
            .Where(f => f.Date == request.Date)
            .FirstAsync(cancellationToken);

    }    
}
