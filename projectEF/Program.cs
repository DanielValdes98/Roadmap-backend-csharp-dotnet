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

app.MapPut("/api/actualizarTarea/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) => 
{
    var tareaActual = dbContext.Tareas.Find(id);

    if (tareaActual != null){
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.Descripcion = tarea.Descripcion;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapDelete("/api/eliminarTarea/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) => 
{
    var tareaActual = dbContext.Tareas.Find(id);

    if (tareaActual != null){
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();

        return Results.Ok($"Tarea con titulo: {tareaActual.Titulo}, se elimino exitosamente");
    }

    return Results.NotFound("Tarea no encontrada");
});


app.Run();
