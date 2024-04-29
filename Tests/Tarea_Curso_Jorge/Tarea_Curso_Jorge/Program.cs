using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Exceptions;
using System.Reflection;
using Tarea_Curso_Jorge.Context;
using Tarea_Curso_Jorge.Models;
using Tarea_Curso_Jorge.Repository;
using Tarea_Curso_Jorge.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);
// Preparamos el lector
IWebHostEnvironment env = builder.Environment;
builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

// Creamos el log
builder.Host.UseSerilog();
Log.Logger = CreateSerilogLogger(builder.Configuration);

Log.Information("Starting web aplication with ({AplicationContext})", typeof(Program).GetTypeInfo().Assembly.GetName().Name);

// Fase 1: Registros de servicios
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GamesDatabase")));
builder.Services.AddScoped<IRepository<Games>, Repository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "demo",
                      policy =>
                      {
                          policy.WithOrigins("*");
                      });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Fase 2: Middelware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

app.MapGet("/AllGames", GetAll)
    .WithName("AllGames")
    .WithOpenApi();

app.MapGet("/ExistGame", ExistGame)
    .WithName("ExistGame")
    .WithOpenApi();

app.MapPost("/InsertGame", InsertGames)
    .WithName("InsertGame")
    .WithOpenApi();

app.MapPut("/Edit", EditGames)
    .WithName("Edit")
    .WithOpenApi();

app.MapDelete("/Delete", DeleteGames)
    .WithName("Delete")
    .WithOpenApi();

app.UseCors("demo");
app.Run();

static IResult GetAll(IUnitOfWork uof)
{
    return Results.Ok(uof._repository.GetAll());
}

static IResult ExistGame(IUnitOfWork uof, string name)
{
    Games g = new Games()
    {
        Titulo = name
    };

    return Results.Ok(uof._repository.FindByCondition(g));
}

static IResult InsertGames(IUnitOfWork uof, string titulo, int puntuacion, float precio)
{
    Games g = new Games(titulo, puntuacion, precio);
    uof._repository.Insert(g);
    uof.Save();
    return Results.Ok("Se ha ingresado el juego correctamente!");
}

static IResult DeleteGames(IUnitOfWork uof, int id)
{
    Games g = new Games()
    {
        Id = id
    };
    if (uof._repository.Delete(g))
    {
        uof.Save();
        return Results.Ok("Se eliminado el juego con el id: " + id);
    }
    return Results.NotFound("No hay ningun Juego con ese Id, no existe");
}

static IResult EditGames(IUnitOfWork uof, int id, string titulo, int puntuacion, float precio)
{
    Games g = new Games(id, titulo, puntuacion, precio);

    if (uof._repository.Update(g))
    {
        uof.Save();
        return Results.Ok($"Se edito el juego con el id: {id}");
    }
    return Results.NotFound($"No hay ningun Juego con ese Id {id}, no existe");
}

Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
{
    var seqServerUrl = configuration["Serilog:SeqServerUrl"];

    return new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .Enrich.WithExceptionDetails()
        .Enrich.WithProperty("ApplicationContext", typeof(Program).GetTypeInfo().Assembly.GetName().Name)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.Seq(string.IsNullOrWhiteSpace(seqServerUrl) ? "http://seq" : seqServerUrl)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}
