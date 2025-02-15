using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext(options);