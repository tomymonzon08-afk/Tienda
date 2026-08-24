using Tienda.Aplicacion;
using Tienda.Aplicacion.Reglas;
using Tienda.Dominio;
using Tienda.Infraestructura;

using var contexto = new TiendaDbContext();
contexto.Database.EnsureCreated();

IProveedorDeFecha reloj = new ProveedorDeFechaSistema();
ICalculadorDeDescuentos descuentos = new CalculadorDeDescuentos(new List<IReglaDeDescuento>
{
    new ReglaDescuentoGolosinas(),
    new ReglaDescuentoPorMonto(),
});

var servicioCategorias = new ServicioDeCategorias(contexto);
var servicioProductos = new ServicioDeProductos(contexto);
var servicioVentas = new ServicioDeVentas(contexto, descuentos, reloj);
var servicioDevoluciones = new ServicioDeDevoluciones(contexto, reloj);
var servicioReportes = new ServicioDeReportes(contexto);

var salir = false;
while (!salir)
{
    MostrarMenu();
    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            // TODO: ABM de categorias (RF-1).
            break;
        case "2":
            // TODO: ABM de productos (RF-2, RF-3).
            break;
        case "3":
            // TODO: registrar venta (RF-4, RF-5).
            break;
        case "4":
            // TODO: registrar devolucion (RF-8, RF-9).
            break;
        case "5":
            // TODO: reporte de total vendido entre fechas (RF-6).
            break;
        case "6":
            // TODO: reporte de ranking de productos (RF-7).
            break;
        case "0":
            salir = true;
            break;
        default:
            Console.WriteLine("Opcion invalida.");
            break;
    }
}

void MostrarMenu()
{
    Console.WriteLine();
    Console.WriteLine("=== Tienda ===");
    Console.WriteLine("1. Categorias (ABM)");
    Console.WriteLine("2. Productos (ABM)");
    Console.WriteLine("3. Registrar venta");
    Console.WriteLine("4. Registrar devolucion");
    Console.WriteLine("5. Total vendido entre fechas");
    Console.WriteLine("6. Ranking de productos");
    Console.WriteLine("0. Salir");
    Console.Write("Opcion: ");
}
