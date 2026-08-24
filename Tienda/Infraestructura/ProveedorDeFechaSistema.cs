using Tienda.Dominio;

namespace Tienda.Infraestructura;

// Unica implementacion que usa DateTime.Now (RN-7): el resto del sistema
// pide la fecha por aca, nunca la escribe directamente.
public class ProveedorDeFechaSistema : IProveedorDeFecha
{
    public DateTime Ahora => DateTime.Now;
}
