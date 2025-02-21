using BookTracker.Application.Behaviors;
using BookTracker.Application.Services.DateTime;
using BookTracker.Application.Services.GuidGenerator;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using Sieve.Services;

namespace BookTracker.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly);

        services.AddSingleton<IDateTimeService, DateTimeService>();
        services.AddSingleton<IGuidGenerator, GuidGenerator>();
        services.AddSingleton<ISieveProcessor, AppSieveProcessor>();

        return services;
    }
}