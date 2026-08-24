using Tienda.Dominio;

namespace Tienda.Aplicacion.Reglas;

// RN-11: los items de la categoria "Golosinas" llevan 20% de descuento
// sobre esos items. Se aplica antes que el descuento por monto (Orden bajo).
public class ReglaDescuentoGolosinas : IReglaDeDescuento
{
    public int Orden => 1;

    public bool AplicaA(Venta venta)
    {
        // TODO: devolver true si la venta tiene al menos un item de la categoria Golosinas.
        throw new NotImplementedException();
    }

    public decimal CalcularDescuento(Venta venta, decimal totalActual)
    {
        // TODO: sumar 20% del subtotal de los items de Golosinas y devolverlo
        // como el monto de descuento (no como el total resultante).
        throw new NotImplementedException();
    }
}
