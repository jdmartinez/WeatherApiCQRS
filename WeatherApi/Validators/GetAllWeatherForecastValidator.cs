using FluentValidation;

using WeatherApi.Queries;

namespace WeatherApi.Validators;

public class GetAllWeatherForecastValidator : AbstractValidator<GetAllWeatherForecastQuery>
{
    public GetAllWeatherForecastValidator()
    {
        RuleFor(f => f.Days)
            .NotNull()
            .GreaterThan(f => 0);
    }
}
