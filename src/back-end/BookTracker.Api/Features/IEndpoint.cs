namespace BookTracker.Api.Features;

public interface IEndpoint
{
    string Group { get; }
    void Map(RouteGroupBuilder builder);
}