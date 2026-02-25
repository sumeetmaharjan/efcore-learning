using System.Text.Json.Serialization;
using EFCoreMovies;
using EFCoreMovies.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    // To prevent the circular dependency when returning json object from API
    .AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IChangeTrackerEventHandler, ChangeTrackerEventHandler>();

// This is comments because its configured via ApplicationDbContext > OnConfiguring override
// if this was un commented, onConfiguration code would not run.
// Database configuration
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    // Global tracking behaviour of EF setup.
    //option.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
    //option.UseLazyLoadingProxies(); // LazyLoading EF Entities Requires EfC.Proxies nuget
    // var useSqlite = builder.Configuration.GetValue<bool>("UseSqlite");
    // if (useSqlite)
    // {
    //     option.UseSqlite("Filename=movies.sqlite");
    // }
    // else
    // {
    option.UseSqlServer("name=DefaultConnection", sqlServer => sqlServer.UseNetTopologySuite());
    // }
});

// This is not actually configuring anything.. This is required for us to be able of inject 
// ApplicationDbContext in controller and stuff.
// builder.Services.AddDbContext<ApplicationDbContext>();

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