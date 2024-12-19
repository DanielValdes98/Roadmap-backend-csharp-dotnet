using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using projectEF.Models;

namespace projectEF;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria { CategoriaId = Guid.Parse("f36c7b0b-bdcf-4c76-8d18-a426c57fc477"), Nombre = "Actividades pendientes", Descripcion = "Descripción de la categoría act pendientes", Peso = 20 });
        categoriasInit.Add(new Categoria { CategoriaId = Guid.Parse("f36c7b0b-bdcf-4c76-8d18-a426c57fc402"), Nombre = "Actividades personales", Descripcion = "Descripción de la categoría act personales", Peso = 20 });

        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("f36c7b0b-bdcf-4c76-8d18-a426c57fc413"), CategoriaId = Guid.Parse("f36c7b0b-bdcf-4c76-8d18-a426c57fc477"), PrioridadTarea = Prioridad.Media, Titulo = "Revisar pago de servicios publicos", Descripcion = "Descripción del pago", FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("f36c7b0b-bdcf-4c76-8d18-a426c57fc412"), CategoriaId = Guid.Parse("f36c7b0b-bdcf-4c76-8d18-a426c57fc402"), PrioridadTarea = Prioridad.Baja, Titulo = "Comprar regalo de cumpleaños", Descripcion = "Descripción de la compra", FechaCreacion = DateTime.Now });

        modelBuilder.Entity<Tarea>(tarea => 
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);

            // Se especifica que existe una propiedad dentro de Tarea que se llama Categoria. Esa Categoria tiene relaci�n (WithMany) con m�ltiples tareas. Po �ltimo, se especifica que existe una llave foranea para la relaci�n. 
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId); 

            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p => p.Resumen);
            tarea.HasData(tareasInit);
        });
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder
    //         .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    // }
}
