using System.Text.Json.Serialization;
using FullstackAfiliados.Api.Configuration;
using FullstackAfiliados.Api.Middlewares;
using FullstackAfiliados.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<GlobalExceptionMiddleware>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<FullstackAfiliadosDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.ResolveDependencies();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Development",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

    options.AddPolicy("Production",
        builder => builder.WithMethods("*")
            .WithOrigins("http://localhost")
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            //.WithHeaders(HeaderNames.ContentType, "x-custom-header")
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();