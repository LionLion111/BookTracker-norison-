using BookTracker.Api;
using BookTracker.Api.Constants;
using BookTracker.Api.Data;
using BookTracker.Api.Data.Entities;

using FastEndpoints;
using FastEndpoints.Swagger;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Scalar.AspNetCore;

using Sieve.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

builder.Services
    .AddIdentityApiEndpoints<User>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services
    .AddAuthorizationBuilder()
    .AddPolicy(AuthPolicy.Admin, policy =>
    {
        policy.RequireAuthenticatedUser().RequireRole(RoleConstants.Admin);
    });

builder.Services.AddSingleton<ISieveProcessor, AppSieveProcessor>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.UseOpenApi(c => c.Path = "/openapi/{documentName}.json");
app.MapScalarApiReference();
app.Run();