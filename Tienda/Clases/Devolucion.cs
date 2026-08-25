namespace Tienda;

public class Devolucion
{
    public int Id { get; set; }

    public Venta? Venta { get; set; }

    public DateTime Fecha { get; set; }
    public decimal MontoReintegrado { get; set; }

    public List<ItemDevolucion> Items { get; set; } = new();

    public static Devolucion Registrar(int ventaId, List<ItemDevolucion> items)
    {
        throw new NotImplementedException();
    }
}
