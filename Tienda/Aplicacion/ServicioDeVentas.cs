using Tienda.Dominio;
using Tienda.Infraestructura;

namespace Tienda.Aplicacion;

// RF-4/RF-5: registrar una venta con uno o varios productos, descontando stock al confirmar.
public class ServicioDeVentas
{
    private readonly TiendaDbContext _contexto;
    private readonly ICalculadorDeDescuentos _descuentos;
    private readonly IProveedorDeFecha _reloj;

    public ServicioDeVentas(TiendaDbContext contexto,
                            ICalculadorDeDescuentos descuentos,
                            IProveedorDeFecha reloj)
    {
        _contexto = contexto;
        _descuentos = descuentos;
        _reloj = reloj;
    }

    // Cada ItemVenta de la lista viene con ProductoId y Cantidad. Nada mas.
    public Venta RegistrarVenta(string cliente, List<ItemVenta> items)
    {
        // TODO:
        // 1. Validar: RN-3 (cantidad > 0), RN-4 (al menos un item), RN-1 (producto activo),
        //    RN-2 (stock suficiente). Si algo falla, RN-5: no se registra nada (todo o nada).
        // 2. Recien ahora: completar PrecioUnitario de cada item con el precio actual del
        //    producto (RN-6), crear la Venta, descontar el stock de cada producto.
        // 3. Calcular el descuento con _descuentos.CalcularDescuentoTotal (RN-8/RN-11) y el
        //    total final redondeado a 2 decimales (RN-9). Usar _reloj.Ahora para la fecha (RN-7).
        // 4. Un unico _contexto.SaveChanges() al final.
        throw new NotImplementedException();
    }
}
