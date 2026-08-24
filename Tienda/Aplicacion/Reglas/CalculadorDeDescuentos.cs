using Tienda.Dominio;

namespace Tienda.Aplicacion.Reglas;

public class CalculadorDeDescuentos : ICalculadorDeDescuentos
{
    private readonly List<IReglaDeDescuento> _reglas;

    public CalculadorDeDescuentos(IEnumerable<IReglaDeDescuento> reglas)
    {
        _reglas = reglas.OrderBy(r => r.Orden).ToList();
    }

    public decimal CalcularDescuentoTotal(Venta venta, decimal totalBruto)
    {
        // TODO: recorrer _reglas en orden, aplicando cada una sobre el total ya
        // rebajado por las anteriores (ver RN-11), y devolver el descuento acumulado.
        throw new NotImplementedException();
    }
}
