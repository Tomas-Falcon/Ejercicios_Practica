//FASE 1:  
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using WebApiAplicacionC1.Infraestructure;
using WebApiAplicacionC1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BloggingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BloggingDatabase")));

//var contextOption = new DbContextOptionsBuilder<BloggingContext>()
//.UseSqlServer(builder.Configuration.GetConnectionString("BloggingDatabase")).Options;




var app = builder.Build();
//FASE 2: Midelware
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    BloggingContext dbcontext = scope.ServiceProvider.GetService<BloggingContext>();
    dbcontext.Database.EnsureCreated();

    var blog = new Blog { Url = "http://sample.com" };

    // Crear una nueva instancia de Post
    var post = new Post { Title = "Hello World", Content = "This is my first post", Blog = blog };

    dbcontext.Blogs.Add(blog);
    dbcontext.Posts.Add(post);
    dbcontext.SaveChanges(); 
}

    var summaries = new[]
    {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
// queremos hacer un nuevo metodo que aña

var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        )).ToList();
    app.MapGet("/weatherforecast", () =>
    {
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MapPost("/NewWeatherforecast", (string text) =>
{
    return $"El usuario ingresó: {text}";
})
.WithName("PostWeatherForecast")
.WithOpenApi();


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
