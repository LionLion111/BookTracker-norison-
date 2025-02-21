namespace BookTracker.Application.Features;

public class PagedListResult<TData>
{
    public int TotalCount { get; set; }
    public IEnumerable<TData> Data { get; set; } = [];
}