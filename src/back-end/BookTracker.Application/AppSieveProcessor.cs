using BookTracker.Persistence.Entities;

using Microsoft.Extensions.Options;

using Sieve.Models;
using Sieve.Services;

namespace BookTracker.Application;

public class AppSieveProcessor : SieveProcessor
{
    public AppSieveProcessor(IOptions<SieveOptions> options) : base(options)
    {
    }

    public AppSieveProcessor(IOptions<SieveOptions> options, ISieveCustomSortMethods customSortMethods) : base(options,
        customSortMethods)
    {
    }

    public AppSieveProcessor(IOptions<SieveOptions> options, ISieveCustomFilterMethods customFilterMethods) : base(
        options, customFilterMethods)
    {
    }

    public AppSieveProcessor(IOptions<SieveOptions> options, ISieveCustomSortMethods customSortMethods,
        ISieveCustomFilterMethods customFilterMethods) : base(options, customSortMethods, customFilterMethods)
    {
    }

    protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
    {
        mapper.Property<Publisher>(x => x.Name).CanFilter().CanSort();
        mapper.Property<Publisher>(x => x.CreatedDateTime).CanFilter().CanSort().HasName("created");
        mapper.Property<Publisher>(x => x.ModifiedDateTime).CanFilter().CanSort().HasName("modified");
        return base.MapProperties(mapper);
    }
}