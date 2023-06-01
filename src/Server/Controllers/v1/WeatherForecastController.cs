using Application.Features.Queries;
using BlazorApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers.v1
{
    [ApiController]
    [Route("api/v1/weather-forecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<WeatherForecast>> GetAsync()
        {
            var response = await _mediator.Send(new FetchForecastsQuery());
            return response;
        }
    }
}
