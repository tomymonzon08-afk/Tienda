namespace Tienda.Dominio;

public interface IReglaDeDescuento
{
    int Orden { get; }                 // menor = se aplica antes (ver RN-11)
    bool AplicaA(Venta venta);
    decimal CalcularDescuento(Venta venta, decimal totalActual);
}
