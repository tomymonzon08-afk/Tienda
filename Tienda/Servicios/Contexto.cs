namespace Tienda;

public static class Contexto
{
    public static TiendaDbContext Db { get; set; } = new TiendaDbContext();
    public static IProveedorDeFecha Reloj { get; set; } = new ProveedorDeFechaSistema();
    public static ICalculadorDeDescuentos Descuentos { get; set; } = null!;
}
