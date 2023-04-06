using FluentValidation;

namespace WeatherApi.Extensions;

public static class ValidationExtensions
{
    public static IDictionary<string, string[]> ToDictionary(this ValidationException exception)
    {
        return exception.Errors
            .GroupBy(e => e.Severity)
            .ToDictionary(error => error.Key.ToString(), error => error.Select(g => g.ErrorMessage).ToArray());
    }
}
