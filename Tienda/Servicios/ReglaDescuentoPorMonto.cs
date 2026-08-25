namespace Tienda;

public class ReglaDescuentoPorMonto : IReglaDeDescuento
{
    public int Orden => 2;

    public bool AplicaA(Venta venta)
    {
        return true;
    }

    public decimal CalcularDescuento(Venta venta, decimal totalActual)
    {
        decimal porcentaje;

        if (totalActual <= 10_000m)
        {
            porcentaje = 0m;
        }
        else if (totalActual <= 50_000m)
        {
            porcentaje = 0.05m;
        }
        else
        {
            porcentaje = 0.10m;
        }

        return totalActual * porcentaje;
    }
}
