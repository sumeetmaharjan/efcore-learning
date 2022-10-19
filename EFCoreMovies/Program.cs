using System.Text.Json.Serialization;
using EFCoreMovies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    // To prevent the circular dependency when returning json object from API
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Database configuration
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    // Global tracking behaviour of EF setup.
    //option.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
    //option.UseLazyLoadingProxies(); // LazyLoading EF Entities Requires EfC.Proxies nuget
    option.UseSqlServer("name=DefaultConnection", sqlServer => sqlServer.UseNetTopologySuite());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
