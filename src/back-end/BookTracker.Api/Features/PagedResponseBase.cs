namespace BookTracker.Api.Features;

public abstract class PagedResponseBase<TData>
{
    public int TotalCount { get; set; }
    public IEnumerable<TData> Data { get; set; } = [];
}