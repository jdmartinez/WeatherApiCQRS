using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using WeatherApi.Extensions;
using WeatherApi.Queries;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("/date")]
        public async Task<IResult> Get([FromQuery] GetWeatherForecastQuery query)
        {
            try
            {
                return Results.Ok(await _mediator.Send(query));
            }
            catch (ValidationException validationEx)
            {
                return Results.ValidationProblem(validationEx.ToDictionary());
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        [HttpGet("/days")]
        public async Task<IResult> GetDays([FromQuery] GetAllWeatherForecastQuery query)
        {
            try
            {
                return Results.Ok(await _mediator.Send(query));
            }
            catch (ValidationException validationEx)
            {
                return Results.ValidationProblem(validationEx.ToDictionary());
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

    }
}