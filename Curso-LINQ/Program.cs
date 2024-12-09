using Curso_LINQ;

LinqQueries queries = new LinqQueries();

// Toda la colección
//ImprimirValores(queries.TodaLaColeccion());

// Libros después del 2000
//ImprimirValores(queries.LibrosDespuesDel2000());

// Libros con más de 250 páginas y las palabras in Action en el título
//ImprimirValores(queries.LibrosMax250PagConPalabrasInAction());

// Todos los libros tienen status
Console.WriteLine($"\n¿Todos los libros tiene Status? - {queries.TodosLosLibrosTienenStatus()}");

// Algún libro fue publicado en el 2005
Console.WriteLine($"\n¿Algún libro fue publicado en el 2005? - {queries.SiAlgunLibroFuePublicado2005()}");

// Elementos de la categoría Python
//ImprimirValores(queries.ElementosConCategoriaPython());

// Libros de la categoría de Java ordenados de forma ascendente
//ImprimirValores(queries.LibrosDeJavaPorNombreAscendente());

// Tres libros más recientes con categoría Java
//ImprimirValores(queries.TresLibrosRecientesConCategoriaJava());

// Tercer y cuarto libro con más de 400 páginas
ImprimirValores(queries.TercerYCuartoLibroConMasDe400Pag());

// Titulo y numero de paginas de los tres primeros libros de la collection
ImprimirValores(queries.TresPrimerosLibrosDeLaCollection());

// Cantidad de libros entre 200 y 500 paginas
Console.WriteLine($"\nCantidad de libros entre 200 y 500 paginas: {queries.LibrosEntre200y500Paginas()}");

void ImprimirValores(IEnumerable<Book> listaDeLibros)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "No. Paginas", "Fecha de publicacion");
    foreach (var item in listaDeLibros)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

