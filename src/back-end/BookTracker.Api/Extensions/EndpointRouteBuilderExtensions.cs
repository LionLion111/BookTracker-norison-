using System.Reflection;

using BookTracker.Api.Features;
using BookTracker.Api.Filters;

namespace BookTracker.Api.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        var endpointGroups = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.GetInterfaces().Contains(typeof(IEndpoint)))
            .Select(Activator.CreateInstance)
            .Cast<IEndpoint>()
            .GroupBy(x => x.Group);

        foreach (var group in endpointGroups)
        {
            var groupBuilder = builder
                .MapGroup(group.Key)
                .RequireAuthorization()
                .ProducesProblem(StatusCodes.Status401Unauthorized)
                .AddEndpointFilter<ExceptionFilter>();

            foreach (var endpoint in group)
            {
                endpoint.Map(groupBuilder);
            }
        }

        return builder;
    }
}