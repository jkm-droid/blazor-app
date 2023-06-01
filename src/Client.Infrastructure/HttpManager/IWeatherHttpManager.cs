using BlazorApp.Shared;

namespace Client.Infrastructure.HttpManager;

public interface IWeatherHttpManager
{
    Task<List<WeatherForecast>> GetWeatherForecastsAsync();
}