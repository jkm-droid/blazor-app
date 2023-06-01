using Client.Infrastructure.HttpManager;
using Microsoft.Net.Http.Headers;

namespace BlazorApp.Client.Extensions;

public static class ServiceExtensions
{
    public static void AddHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<IWeatherHttpManager, WeatherHttpManager>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:6001");
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        });
    }
}