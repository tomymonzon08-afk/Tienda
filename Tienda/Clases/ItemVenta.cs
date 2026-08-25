namespace Tienda;

public class ItemVenta
{
    public int Id { get; set; }

    public Venta? Venta { get; set; }

    public Producto? Producto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }
}
