using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_LINQ
{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();

        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<Book>().ToList();
            }
        }

        public IEnumerable<Book> TodaLaColeccion()
        {
            return librosCollection;
        }

        public IEnumerable<Book> LibrosDespuesDel2000()
        {
            // Extension method
            //return librosCollection.Where(l => l.PublishedDate.Year > 2000);

            // Query expression
            return from libro in librosCollection where libro.PublishedDate.Year > 200 select libro;
        }

        public IEnumerable<Book> LibrosMax250PagConPalabrasInAction()
        {
            // Extension method
            //return librosCollection.Where(l => l.PageCount > 250 && l.Title.Contains("in Action"));

            // Query expression
            return from libro in librosCollection where libro.PageCount > 250 && libro.Title.Contains("in Action") select libro ;
        }

        public bool TodosLosLibrosTienenStatus()
        {
            return librosCollection.All(l => l.Status != string.Empty);
        }
        
        public bool SiAlgunLibroFuePublicado2005()
        {
            return librosCollection.Any(l => l.PublishedDate.Year == 2005);
        }
        
        public IEnumerable<Book> ElementosConCategoriaPython()
        {
            return librosCollection.Where(l => l.Categories.Contains("Python", StringComparer.CurrentCultureIgnoreCase));
        }

        public IEnumerable<Book> LibrosDeJavaPorNombreAscendente()
        {
            return librosCollection.Where(l => l.Categories.Contains("Java", StringComparer.CurrentCultureIgnoreCase))
                .OrderBy(l => l.Title);
        }

        public IEnumerable<Book> TresLibrosRecientesConCategoriaJava()
        {
            return librosCollection
                .Where(l => l.Categories.Contains("Java", StringComparer.CurrentCultureIgnoreCase))
                .OrderBy(l => l.PublishedDate)
                .TakeLast(3);
        }

        public IEnumerable<Book> TercerYCuartoLibroConMasDe400Pag()
        {
            return librosCollection.Where(l => l.PageCount > 400).Take(4).Skip(2);
        }

        public IEnumerable<Book> TresPrimerosLibrosDeLaCollection()
        {
            return librosCollection.Take(3)
                .Select(l => new Book { Title = l.Title, PageCount = l.PageCount });
        }

        public int LibrosEntre200y500Paginas()
        {
            return librosCollection.Count(l => l.PageCount >= 200 && l.PageCount <= 500);
        }

        public DateTime FechaPublicacionMinima()
        {
            return librosCollection.Min(l => l.PublishedDate);
        }

        public int NumeroPagLibroMayor()
        {
            return librosCollection.Max(l => l.PageCount);
        }

        public Book? LibroMenorCantPaginasMayorACero()
        {
            return librosCollection.MinBy(l => l.PageCount > 0);
        }

        public Book? LibroConFechaPublicacionMasReciente()
        {
            return librosCollection.MaxBy(l => l.PublishedDate);
        }

        public int SumaTodasLasPaginasLibrosEntre0y500()
        {
            return librosCollection.Where(l => l.PageCount >= 0 && l.PageCount <= 500).Sum(l => l.PageCount);
        }

        public string TitulosLibrosDespuesDel2015Concatenados()
        {
            return librosCollection
                .Where(l => l.PublishedDate.Year > 2015)
                .Aggregate("", (TitulosLibros, next) =>
                {
                    if (TitulosLibros != "")
                    {
                        TitulosLibros += " - " + next.Title;
                    }
                    else
                    {
                        TitulosLibros += next.Title;
                    }

                    return TitulosLibros;
                });
        }

        public double PromedioCaracteresTitulosLibros()
        {
            return librosCollection.Average(l => l.Title.Length);
        }

        public IEnumerable<IGrouping<int,Book>> LibrosDespuesDel200AgrupadosPorAno()
        {
            return librosCollection.Where(l => l.PublishedDate.Year > 2000).GroupBy(l => l.PublishedDate.Year);
        }

        public ILookup<char, Book> DiccionarioLibrosPorLetra()
        {
            return librosCollection.ToLookup(l => l.Title[0], p => p);
        }

        public IEnumerable<Book> LibrosDespues2005yMas500Paginas()
        {
            var librosDespues2005 = librosCollection.Where(l => l.PublishedDate.Year > 2005);
            var librosMas500Paginas = librosCollection.Where(l => l.PageCount > 500);

            return librosDespues2005.Join(librosMas500Paginas, cl1 => cl1.Title, cl2 => cl2.Title, (cl1, cl2) => cl1);
        }
    }
}
