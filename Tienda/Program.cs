using Tienda;

Contexto.Db.Database.EnsureCreated();
Contexto.Descuentos = new CalculadorDeDescuentos(new List<IReglaDeDescuento>
{
    new ReglaDescuentoGolosinas(),
    new ReglaDescuentoPorMonto(),
});

var salir = false;
while (!salir)
{
    MostrarMenu();
    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            break;
        case "2":
            break;
        case "3":
            break;
        case "4":
            break;
        case "5":
            break;
        case "6":
            break;
        case "0":
            salir = true;
            break;
        default:
            Console.WriteLine("Opcion invalida.");
            break;
    }
}

Contexto.Db.Dispose();

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
