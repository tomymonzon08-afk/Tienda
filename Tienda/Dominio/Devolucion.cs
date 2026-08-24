namespace Tienda.Dominio;

public class Devolucion
{
    public int Id { get; set; }

    public int VentaId { get; set; }
    public Venta? Venta { get; set; }

    public DateTime Fecha { get; set; }
    public decimal MontoReintegrado { get; set; }

    public List<ItemDevolucion> Items { get; set; } = new();
}
