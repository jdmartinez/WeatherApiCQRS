using FluentValidation;

using WeatherApi.Queries;

namespace WeatherApi.Validators;

public class GetWeatherForecastValidator : AbstractValidator<GetWeatherForecastQuery>
{
    public GetWeatherForecastValidator()
    {
        RuleFor(f => f.Date)
            .NotNull()
            .GreaterThanOrEqualTo(f => DateOnly.FromDateTime(DateTime.Now));
    }
}
