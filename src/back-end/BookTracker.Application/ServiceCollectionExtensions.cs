using BookTracker.Application.Services.DateTime;
using BookTracker.Application.Services.GuidGenerator;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace BookTracker.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
        });

        services.AddValidatorsFromAssembly(assembly);

        services.AddSingleton<IDateTimeService, DateTimeService>();
        services.AddSingleton<IGuidGenerator, GuidGenerator>();

        return services;
    }
}