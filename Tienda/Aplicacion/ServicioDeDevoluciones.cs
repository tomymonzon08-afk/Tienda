using Tienda.Dominio;
using Tienda.Infraestructura;

namespace Tienda.Aplicacion;

// RF-8/RF-9: registrar una devolucion (total o parcial) y reponer stock.
public class ServicioDeDevoluciones
{
    private readonly TiendaDbContext _contexto;
    private readonly IProveedorDeFecha _reloj;

    public ServicioDeDevoluciones(TiendaDbContext contexto, IProveedorDeFecha reloj)
    {
        _contexto = contexto;
        _reloj = reloj;
    }

    public Devolucion RegistrarDevolucion(int ventaId, List<ItemDevolucion> items)
    {
        // TODO:
        // 1. Validar: RN-14 (la venta existe y la cantidad a devolver es > 0), RN-12 (no
        //    devolver mas unidades de las vendidas, contando devoluciones anteriores del
        //    mismo ItemVenta). Si algo falla, RN-15: no se registra nada (todo o nada).
        // 2. Recien ahora: crear la Devolucion, reponer el stock de cada producto (RF-9),
        //    y calcular MontoReintegrado con el precio congelado del ItemVenta (RN-13).
        // 3. Usar _reloj.Ahora para la fecha. Un unico _contexto.SaveChanges() al final.
        throw new NotImplementedException();
    }
}
