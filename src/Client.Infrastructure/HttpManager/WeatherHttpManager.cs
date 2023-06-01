using System.Text.Json;
using BlazorApp.Shared;
using BlazorApp.Shared.Helpers;

namespace Client.Infrastructure.HttpManager;

public class WeatherHttpManager : IWeatherHttpManager
{
    private readonly HttpClient _httpClient;

    public WeatherHttpManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<WeatherForecast>> GetWeatherForecastsAsync()
    {
        var url = new UrlFormatter().SetBaseUrl("api/v1/weather-forecast").ToString();
        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        var forecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(content);
        return forecasts ?? new List<WeatherForecast>();
    }
}