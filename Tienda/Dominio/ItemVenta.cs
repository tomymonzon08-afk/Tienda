namespace Tienda.Dominio;

public class ItemVenta
{
    public int Id { get; set; }

    public int VentaId { get; set; }
    public Venta? Venta { get; set; }

    public int ProductoId { get; set; }
    public Producto? Producto { get; set; }

    public int Cantidad { get; set; }

    // Precio "congelado" al momento de la venta (RN-6). No se toca aunque cambie el precio del producto.
    public decimal PrecioUnitario { get; set; }
}
