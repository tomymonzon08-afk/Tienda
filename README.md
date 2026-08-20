# TP Tienda — Sistema de Ventas

---

## 1. Situación problemática

El bar de la escuela lleva las ventas en un cuaderno. A fin de mes nadie sabe cuánto se vendió, qué producto se quedó sin stock ni cuál categoría deja más ganancia.

Nos piden desarrollar **el motor de un sistema de ventas**: la parte que guarda los datos y aplica las reglas del negocio. Hacer una app de consola mínima para probar con un menú.

---

## 2. Modelo de dominio

El sistema trabaja con estas entidades. **Definir los campos, los tipos de dato y las validaciones de cada una es parte del trabajo**: piensen qué datos necesita realmente el negocio antes de escribir la primera clase. Estas son las entidades mínimas, si lo consideran correcto o necesario pueden agregar más.

- **Categoría** — agrupa productos (Golosinas, Bebidas, Librería…).
- **Producto** — lo que se vende. Pertenece a una categoría y tiene un precio y un stock.
- **Venta** — una operación completa, con su fecha y su total.
- **ItemVenta** — cada renglón de la venta: qué producto, cuántas unidades y a qué precio.
- **Devolución** — el registro de una devolución sobre una venta ya hecha.

**Relaciones:** una categoría tiene muchos productos · una venta tiene muchos ítems · cada ítem apunta a un producto · una devolución se refiere a una venta.

Cómo modelar la devolución queda a criterio de cada uno: pueden guardar qué productos y cuántas unidades se devolvieron, o resolverla de otra forma. Lo importante es que después se pueda responder **"¿cuánto quedó realmente vendido?"** (RF‑10) y que no se pueda devolver dos veces lo mismo (RN‑12).

---

## 3. Requisitos funcionales

| # | Requisito |
|---|---|
| RF‑1 | Alta, baja (lógica) y modificación de **categorías**. |
| RF‑2 | Alta, baja (lógica) y modificación de **productos**, asignándolos a una categoría existente. |
| RF‑3 | Listar productos filtrando por categoría y/o por nombre. |
| RF‑4 | Registrar una **venta** con uno o varios productos y sus cantidades. |
| RF‑5 | Descontar el stock de cada producto al confirmar la venta. |
| RF‑6 | Consultar el **total vendido** entre dos fechas. |
| RF‑7 | Consultar el **ranking de productos más vendidos** (por unidades). |
| RF‑8 | Registrar la **devolución** de una venta, total o parcial (algunos productos y no todos). |
| RF‑9 | **Reponer el stock** de los productos devueltos. |
| RF‑10 | Los reportes RF‑6 y RF‑7 deben **descontar lo devuelto**: si se vendieron 10 alfajores y se devolvieron 3, el ranking muestra 7. |
| RF‑11 | El sistema debe permitir el **ABM completo de todas las entidades** del modelo, accesible desde el menú de la consola. |

Cómo organizar el ABM queda a criterio de cada uno. Piensen dónde tiene que vivir la validación para que no se repita, y qué significa "dar de baja" en cada caso.

---

## 4. Reglas de negocio

| # | Regla |
|---|---|
| RN‑1 | No se puede vender un producto **inactivo**. |
| RN‑2 | No se puede vender más unidades de las que hay en **stock**. |
| RN‑3 | La cantidad de un ítem debe ser **mayor que cero**. |
| RN‑4 | Una venta debe tener **al menos un ítem**. |
| RN‑5 | Si algún ítem es inválido, **no se registra nada** de la venta (todo o nada). |
| RN‑6 | El precio unitario del ítem se "congela" con el precio del producto al momento de la venta. Si mañana cambia el precio, las ventas viejas no cambian. |
| RN‑7 | La fecha de la venta la provee un servicio, **nunca** `DateTime.Now` escrito dentro de la lógica. |
| RN‑8 | Descuentos según el total bruto: <br>• hasta $10.000 → 0 % <br>• más de $10.000 y hasta $50.000 → 5 % <br>• más de $50.000 → 10 % |
| RN‑9 | El total final se redondea a 2 decimales. |
| RN‑10 | No se puede eliminar una categoría que tenga productos asociados. |
| RN‑11 | Promoción de categoría: los productos de la categoría *Golosinas* llevan un 20 % de descuento **sobre esos ítems**. Se aplica antes que la RN‑8, y el descuento por monto se calcula sobre el total ya rebajado. |
| RN‑12 | No se puede devolver más unidades de las que se vendieron en esa venta, contando las devoluciones anteriores. |
| RN‑13 | El monto a reintegrar usa el **precio congelado del ítem** (RN‑6), no el precio actual del producto. |
| RN‑14 | No se puede devolver una venta que no existe, y la cantidad a devolver debe ser mayor que cero. |
| RN‑15 | Si algún renglón de la devolución es inválido, **no se registra nada** de la devolución (todo o nada, igual que RN‑5). |

---

## 5. Interfaces sugeridas

```csharp
// Dominio
public interface IProveedorDeFecha
{
    DateTime Ahora { get; }
}

public interface IReglaDeDescuento
{
    int Orden { get; }                 // menor = se aplica antes (ver RN‑11)
    bool AplicaA(Venta venta);
    decimal CalcularDescuento(Venta venta, decimal totalActual);
}

public interface ICalculadorDeDescuentos
{
    // Recorre las reglas en orden y devuelve el descuento total de la venta.
    decimal CalcularDescuentoTotal(Venta venta, decimal totalBruto);
}
```

Los servicios reciben el `TiendaDbContext` **por constructor**. No hay que armar repositorios: `DbSet<T>` ya cumple ese rol.

```csharp
// Aplicacion
public class ServicioDeVentas
{
    private readonly TiendaDbContext _contexto;
    private readonly ICalculadorDeDescuentos _descuentos;
    private readonly IProveedorDeFecha _reloj;

    public ServicioDeVentas(TiendaDbContext contexto,
                            ICalculadorDeDescuentos descuentos,
                            IProveedorDeFecha reloj)
    {
        _contexto = contexto;
        _descuentos = descuentos;
        _reloj = reloj;
    }

    // Cada ItemVenta de la lista viene con ProductoId y Cantidad. Nada más.
    public Venta RegistrarVenta(string cliente, List<ItemVenta> items) { /* ... */ }
}

public class ServicioDeDevoluciones
{
    // ... dependencias por constructor, igual que arriba ...

    public Devolucion RegistrarDevolucion(int ventaId, List<ItemDevolucion> items) { /* ... */ }
}
```

El menú de consola arma la lista y se la pasa al servicio:

```csharp
var items = new List<ItemVenta>();
items.Add(new ItemVenta { ProductoId = 5, Cantidad = 2 });
items.Add(new ItemVenta { ProductoId = 8, Cantidad = 1 });

var venta = servicio.RegistrarVenta("Ana", items);
```

La consola solo carga **qué producto y cuántas unidades**. El `PrecioUnitario` lo completa el servicio buscando el producto en la base (RN‑6), y la fecha, los descuentos y el total también salen de ahí. Si el menú manda un precio, el servicio **lo pisa igual**: nadie de afuera decide cuánto cuesta algo.

Fíjense que la regla de descuento recibe la **venta completa**, no solo un número: sin eso, una promoción por categoría (RN‑11) no tendría forma de saber qué ítems son de Golosinas. La propiedad `Orden` existe porque el 20 % de categoría va antes que el descuento por monto.

### Cómo se cumple el "todo o nada" (RN‑5 y RN‑15)

Primero se **valida todo**, después se **guarda todo**. El `SaveChanges()` va una sola vez, al final del método, cuando ya no queda nada que pueda fallar:

```csharp
// 1. Validar cada ítem contra las reglas. Si algo falla → excepción, y se corta acá.
// 2. Recién ahora: crear la venta, agregar los ítems, descontar el stock.
// 3. Un único _contexto.SaveChanges() al final.
```

Si `SaveChanges()` nunca se ejecuta, EF Core no escribe nada en la base: los cambios quedan solo en memoria y se descartan. Por eso **no puede haber un `SaveChanges()` adentro del `foreach`** que recorre los ítems: si el tercero falla, los dos primeros ya se guardaron y la venta quedó a medias.

> **Todo el proyecto es síncrono.** No se usa `async`, `await` ni `Task`. Los métodos de EF Core van en su versión común: `ToList()`, `Find()`, `FirstOrDefault()`, `SaveChanges()` — **no** `ToListAsync()`, `SaveChangesAsync()`, etc.

---

## 6. Errores frecuentes (leer antes de entregar)

- La lógica de la venta terminó escrita adentro del `switch` del menú de consola.
- El servicio hace `new TiendaDbContext()` adentro en vez de recibirlo por constructor.
- Hay un `SaveChanges()` adentro del `foreach` de los ítems → viola RN‑5.
- La cadena de conexión está hardcodeada en tres lugares distintos.
- Los descuentos se resolvieron con `if (total > 50000)` dentro del servicio.
- El ítem guarda el `ProductoId` pero lee el precio desde el producto al mostrar el ticket → viola RN‑6.
- La devolución repone el stock pero no queda registrada, así que se puede devolver la misma venta veinte veces.
- El reintegro se calcula con el precio actual del producto en vez del congelado → viola RN‑13.
- El 20 % de Golosinas se resolvió con un `if (categoria.Nombre == "Golosinas")` adentro del servicio de ventas.
- Entregan una sola clase de 400 líneas llamada `Sistema`.
