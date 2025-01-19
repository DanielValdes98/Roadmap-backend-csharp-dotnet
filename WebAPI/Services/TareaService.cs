using webapi;
using webapi.Models;

namespace WebAPI.Services
{
    public class TareaService : ITareaService
    {
        private readonly TareasContext _context;

        public TareaService(TareasContext context)
        {
            _context = context;
        }

        public IEnumerable<Tarea> Get()
        {
            return _context.Tareas;
        }

        public async Task Save(Tarea tarea)
        {
            _context.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Tarea tarea)
        {
            var tareaActual = _context.Tareas.Find(id);
            if (tareaActual != null)
            {
                tareaActual.Titulo = tarea.Titulo;
                tareaActual.Descripcion = tarea.Descripcion;
                tareaActual.PrioridadTarea = tarea.PrioridadTarea;
                tareaActual.CategoriaId = tarea.CategoriaId;
                tareaActual.Resumen = tarea.Resumen;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var tareaActual = _context.Tareas.Find(id);
            if (tareaActual != null)
            {
                _context.Remove(tareaActual);
                await _context.SaveChangesAsync();
            }
        }
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete(Guid id);
}
