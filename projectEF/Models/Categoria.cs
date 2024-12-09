namespace projectEF.Models;

public class Categoria 
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public virtual ICollection<Tarea> Tareas { get; set; }
}