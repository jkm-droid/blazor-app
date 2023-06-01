namespace BlazorApp.Server.Extensions;

public static class ServiceExtensions
{
    public static void AddCorPolicies(this IServiceCollection services)
    {
        services.AddCors(policy =>
        {
            policy.AddPolicy("CorsPolicy", opt => opt
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
        });
    }
}