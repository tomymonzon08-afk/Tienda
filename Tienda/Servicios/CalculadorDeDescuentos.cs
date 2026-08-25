namespace Tienda;

public class CalculadorDeDescuentos : ICalculadorDeDescuentos
{
    private readonly List<IReglaDeDescuento> _reglas;

    public CalculadorDeDescuentos(IEnumerable<IReglaDeDescuento> reglas)
    {
        _reglas = reglas.OrderBy(r => r.Orden).ToList();
    }

    public decimal CalcularDescuentoTotal(Venta venta, decimal totalBruto)
    {
        var totalActual = totalBruto;
        var descuentoAcumulado = 0m;

        foreach (var regla in _reglas)
        {
            if (!regla.AplicaA(venta))
            {
                continue;
            }

            var descuento = regla.CalcularDescuento(venta, totalActual);

            descuentoAcumulado += descuento;
            totalActual -= descuento;
        }

        return descuentoAcumulado;
    }
}
