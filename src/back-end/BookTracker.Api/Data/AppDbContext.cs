using BookTracker.Api.Data.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User, Role, Guid>(options)
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<UserBook> UserBooks => Set<UserBook>();
    public DbSet<UserBookTracker> UserBookTrackers => Set<UserBookTracker>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}