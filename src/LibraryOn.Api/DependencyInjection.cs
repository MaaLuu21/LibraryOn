using LibraryOn.Application.Services;
using LibraryOn.Api.Services;

namespace LibraryOn.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IRegionProvider, HttpRegionProvider>();

        return services;
    }
}
