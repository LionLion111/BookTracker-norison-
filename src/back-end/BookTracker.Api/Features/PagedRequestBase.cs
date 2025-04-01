namespace BookTracker.Api.Features;

public abstract class PagedRequestBase
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string? Filters { get; set; }
    public string? Sorts { get; set; }
}