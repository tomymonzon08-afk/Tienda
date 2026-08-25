namespace Tienda;

public class ReglaDescuentoGolosinas : IReglaDeDescuento
{
    public int Orden => 1;

    private const string NombreCategoria = "Golosinas";
    private const decimal Porcentaje = 0.20m;

    public bool AplicaA(Venta venta)
    {
        return venta.Items.Any(EsGolosina);
    }

    public decimal CalcularDescuento(Venta venta, decimal totalActual)
    {
        var subtotalGolosinas = venta.Items
            .Where(EsGolosina)
            .Sum(item => item.PrecioUnitario * item.Cantidad);

        return subtotalGolosinas * Porcentaje;
    }

    private static bool EsGolosina(ItemVenta item)
    {
        return item.Producto?.Categoria?.Nombre == NombreCategoria;
    }
}
