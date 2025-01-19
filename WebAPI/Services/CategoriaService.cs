using webapi;
using webapi.Models;

namespace WebAPI.Services
{
    public class CategoriaService: ICategoriaService
    {
        private readonly TareasContext _context;

        public CategoriaService(TareasContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Get()
        {
            return _context.Categorias;
        }

        public async Task Save(Categoria categoria)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Categoria categoria)
        {
            var categoriaActual = _context.Categorias.Find(id);
            if (categoriaActual != null)
            {
                categoriaActual.Nombre = categoria.Nombre;
                categoriaActual.Descripcion = categoria.Descripcion;
                categoriaActual.Peso = categoria.Peso;

                _context.Update(categoriaActual);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var categoriaActual = _context.Categorias.Find(id);
            if (categoriaActual != null)
            {
                _context.Remove(categoriaActual);
                await _context.SaveChangesAsync();
            }
        }
    }
}   

public interface ICategoriaService
{   
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}
