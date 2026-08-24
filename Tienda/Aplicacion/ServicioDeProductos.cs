using Tienda.Dominio;
using Tienda.Infraestructura;

namespace Tienda.Aplicacion;

// RF-2: alta, baja (logica) y modificacion de productos, asignados a una categoria existente.
// RF-3: listar productos filtrando por categoria y/o por nombre.
public class ServicioDeProductos
{
    private readonly TiendaDbContext _contexto;

    public ServicioDeProductos(TiendaDbContext contexto)
    {
        _contexto = contexto;
    }

    public List<Producto> Listar(int? categoriaId = null, string? nombre = null)
    {
        // TODO: filtrar por categoriaId y/o nombre cuando vengan informados.
        throw new NotImplementedException();
    }

    public Producto Crear(string nombre, decimal precio, int stock, int categoriaId)
    {
        // TODO: validar datos y que la categoria exista, crear el producto y guardarlo.
        throw new NotImplementedException();
    }

    public void Modificar(int productoId, string nombre, decimal precio, int categoriaId)
    {
        // TODO: buscar el producto y actualizar sus datos.
        throw new NotImplementedException();
    }

    public void Eliminar(int productoId)
    {
        // TODO: baja logica (Activo = false).
        throw new NotImplementedException();
    }
}
