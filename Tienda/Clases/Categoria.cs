using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tienda;

public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public bool Activa { get; set; } = true;

    public List<Producto> Productos { get; set; } = new();

    public static List<Categoria> Listar()
    {
        return Contexto.Db.Categorias.ToList();
    }

    public static Categoria Crear(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre de la categoria es obligatorio.");

        var categoria = new Categoria { Nombre = nombre.Trim() };

        Contexto.Db.Categorias.Add(categoria);
        Contexto.Db.SaveChanges();

        return categoria;
    }

    public void Modificar(string nuevoNombre)
    {
        if (string.IsNullOrWhiteSpace(nuevoNombre))
            throw new ArgumentException("El nombre de la categoria es obligatorio.");

        Nombre = nuevoNombre;
        Contexto.Db.SaveChanges();
    }

    public void Eliminar()
    {
        Activa = false;
        Contexto.Db.SaveChanges();
    }
}
