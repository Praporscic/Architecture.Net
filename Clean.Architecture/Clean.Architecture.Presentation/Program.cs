using Clean.Architecture.Domain.Abstractions;
using Clean.Architecture.Infrastructure;
using Clean.Architecture.Infrastructure.Repositories;
using Clean.Architecture.Presentation.Middleware;
using Serilog;
using System.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Application")));

builder.Services.AddScoped<IWebinarRepository, WebinarRepository>();

builder.Services.AddScoped<IUnitOfWork>(
    factory => factory.GetRequiredService<ApplicationDbContext>());

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();