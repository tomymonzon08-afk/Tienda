namespace Tienda.Dominio;

public class ItemDevolucion
{
    public int Id { get; set; }

    public int DevolucionId { get; set; }
    public Devolucion? Devolucion { get; set; }

    // Se referencia el ItemVenta original para poder validar RN-12 (no devolver
    // mas unidades de las vendidas, contando devoluciones anteriores) y para
    // reintegrar con el precio congelado (RN-13).
    public int ItemVentaId { get; set; }
    public ItemVenta? ItemVenta { get; set; }

    public int Cantidad { get; set; }
}
