using Tienda.Dominio;
using Tienda.Infraestructura;

namespace Tienda.Aplicacion;

// RF-1: alta, baja (logica) y modificacion de categorias.
public class ServicioDeCategorias
{
    private readonly TiendaDbContext _contexto;

    public ServicioDeCategorias(TiendaDbContext contexto)
    {
        _contexto = contexto;
    }

    public List<Categoria> Listar()
    {
        return _contexto.Categorias.ToList();
    }

    public Categoria Crear(string nombre)
    {
        // TODO: validar nombre, crear la categoria y guardarla.
        throw new NotImplementedException();
    }

    public void Modificar(int categoriaId, string nuevoNombre)
    {
        // TODO: buscar la categoria y actualizar el nombre.
        throw new NotImplementedException();
    }

    public void Eliminar(int categoriaId)
    {
        // TODO: baja logica. RN-10: no se puede eliminar una categoria con productos asociados.
        throw new NotImplementedException();
    }
}
