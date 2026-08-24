using Tienda.Dominio;

namespace Tienda.Aplicacion.Reglas;

// RN-8: descuento segun el total bruto (ya con el descuento de categoria aplicado, ver RN-11).
// hasta $10.000 -> 0% | mas de $10.000 y hasta $50.000 -> 5% | mas de $50.000 -> 10%
public class ReglaDescuentoPorMonto : IReglaDeDescuento
{
    public int Orden => 2;

    public bool AplicaA(Venta venta)
    {
        // TODO: esta regla siempre aplica (o definir el criterio si se prefiere otro).
        throw new NotImplementedException();
    }

    public decimal CalcularDescuento(Venta venta, decimal totalActual)
    {
        // TODO: calcular el porcentaje segun totalActual y devolver el monto de descuento.
        throw new NotImplementedException();
    }
}
