namespace BookTracker.Application.Features;

public abstract class PagedQuery<TData> : IQuery<PagedListResult<TData>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string? Filters { get; set; }
    public string? Sorts { get; set; }
}