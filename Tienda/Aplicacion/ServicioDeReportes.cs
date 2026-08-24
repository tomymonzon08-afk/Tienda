using Tienda.Infraestructura;

namespace Tienda.Aplicacion;

// RF-6/RF-7/RF-10: reportes de ventas, descontando siempre lo devuelto.
public class ServicioDeReportes
{
    private readonly TiendaDbContext _contexto;

    public ServicioDeReportes(TiendaDbContext contexto)
    {
        _contexto = contexto;
    }

    public decimal TotalVendidoEntre(DateTime desde, DateTime hasta)
    {
        // TODO: sumar TotalFinal de las ventas en el rango, descontando lo devuelto (RF-10).
        throw new NotImplementedException();
    }

    public List<(string Producto, int UnidadesVendidas)> RankingDeProductos()
    {
        // TODO: agrupar por producto sumando cantidades vendidas menos las devueltas (RF-10),
        // ordenado de mayor a menor.
        throw new NotImplementedException();
    }
}
