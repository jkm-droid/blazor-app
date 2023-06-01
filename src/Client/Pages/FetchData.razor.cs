using BlazorApp.Shared;
using Client.Infrastructure.HttpManager;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Pages;

public partial class FetchData
{
    [Inject] public IWeatherHttpManager WeatherHttpManager { get; set; }
    private List<WeatherForecast> forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await WeatherHttpManager.GetWeatherForecastsAsync();
    }
}