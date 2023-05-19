using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Interface;
using Pokedex.Infraestructure.Data;
using Pokedex.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<IPokemonRepository, PokemonRepository>();
builder.Services.AddTransient<ISpeciesRepository, SpeciesRepository>();
builder.Services.AddTransient<IStatsRepository, StatsRepository>();
builder.Services.AddTransient<ITypesRepository, TypeRepository>();

// Add services to the container.

builder.Services.AddDbContext<DbPokedexContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pokedex"))

 );

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
