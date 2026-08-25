namespace Tienda;

public class Venta
{
    public int Id { get; set; }
    public string Cliente { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public decimal TotalBruto { get; set; }
    public decimal Descuento { get; set; }
    public decimal TotalFinal { get; set; }

    public List<ItemVenta> Items { get; set; } = new();
    public List<Devolucion> Devoluciones { get; set; } = new();

    public static Venta Registrar(string cliente, List<ItemVenta> items)
    {
        throw new NotImplementedException();
    }
}
