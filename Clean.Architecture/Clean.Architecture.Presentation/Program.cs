using Clean.Architecture.Application.Extensions;
using Clean.Architecture.Domain.Abstractions;
using Clean.Architecture.Infrastructure;
using Clean.Architecture.Infrastructure.Repositories;
using Clean.Architecture.Presentation.Middleware;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Application")));

builder.Services.AddScoped<IWebinarRepository, WebinarRepository>();

builder.Services.AddScoped<IUnitOfWork>(
    factory => factory.GetRequiredService<ApplicationDbContext>());

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

//builder.Services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<IDbConnection>(
factory => factory.GetRequiredService<ApplicationDbContext>().Database.GetDbConnection());

builder.Services.ApplicationLayerRegistration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();               // Generate Swagger JSON
    app.UseSwaggerUI();             // Enable Swagger UI
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();