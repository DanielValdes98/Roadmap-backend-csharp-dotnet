using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    await dbContext.Database.EnsureCreatedAsync();
    return Results.Ok($"Base de datos en memoria: {dbContext.Database.IsInMemory()}");
});

app.Run();
