using BlazorApp.Shared;
using MediatR;

namespace Application.Features.Queries;

public class FetchForecastsQuery : IRequest<List<WeatherForecast>>
{
    public FetchForecastsQuery()
    {
        
    }
}

internal sealed class FetchForecastsQueryHandler : IRequestHandler<FetchForecastsQuery, List<WeatherForecast>>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    public Task<List<WeatherForecast>> Handle(FetchForecastsQuery request, CancellationToken cancellationToken)
    {
        var rng = new Random();
        var forecasts =  Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();

        return Task.FromResult(forecasts);
    }
}