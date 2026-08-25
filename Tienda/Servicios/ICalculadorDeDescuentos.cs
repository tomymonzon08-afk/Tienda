namespace Tienda;

public interface ICalculadorDeDescuentos
{
    decimal CalcularDescuentoTotal(Venta venta, decimal totalBruto);
}
