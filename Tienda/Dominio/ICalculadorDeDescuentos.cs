namespace Tienda.Dominio;

public interface ICalculadorDeDescuentos
{
    // Recorre las reglas en orden y devuelve el descuento total de la venta.
    decimal CalcularDescuentoTotal(Venta venta, decimal totalBruto);
}
