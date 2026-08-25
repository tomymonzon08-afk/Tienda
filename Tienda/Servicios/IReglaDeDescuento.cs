namespace Tienda;

public interface IReglaDeDescuento
{
    int Orden { get; }
    bool AplicaA(Venta venta);
    decimal CalcularDescuento(Venta venta, decimal totalActual);
}
