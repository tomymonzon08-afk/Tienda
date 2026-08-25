namespace Tienda;

public class ItemDevolucion
{
    public int Id { get; set; }

    public Devolucion? Devolucion { get; set; }

    public ItemVenta? ItemVenta { get; set; }

    public int Cantidad { get; set; }
}
