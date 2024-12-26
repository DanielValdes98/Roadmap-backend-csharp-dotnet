using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;
using projectEF.Models;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB")); // Base de datos en memoria
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("DefaultConnection")); // Base de datos SQL Server

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    await dbContext.Database.EnsureCreatedAsync();
    return Results.Ok($"Base de datos en memoria: {dbContext.Database.IsInMemory()}");
});

app.MapGet("/api/consultarTareas", async ([FromServices] TareasContext dbContext) => 
{
    var tareas = await dbContext.Tareas.Include(t => t.Categoria).ToListAsync();
    return Results.Ok(tareas);
});

app.MapPost("/api/agregarTarea", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) => 
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea); // Opción 1 para agregar un registro
    // await dbContext.Tareas.AddAsync(tarea); // Opción 2 para agregar un registro

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.Run();
