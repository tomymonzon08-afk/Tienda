using Microsoft.EntityFrameworkCore;
using Tienda.Dominio;

namespace Tienda.Infraestructura;

public class TiendaDbContext : DbContext
{
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Venta> Ventas => Set<Venta>();
    public DbSet<ItemVenta> ItemsVenta => Set<ItemVenta>();
    public DbSet<Devolucion> Devoluciones => Set<Devolucion>();
    public DbSet<ItemDevolucion> ItemsDevolucion => Set<ItemDevolucion>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=tienda.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>()
            .Property(p => p.Precio)
            .HasPrecision(18, 2);

        modelBuilder.Entity<ItemVenta>()
            .Property(i => i.PrecioUnitario)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Venta>()
            .Property(v => v.TotalBruto)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Venta>()
            .Property(v => v.Descuento)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Venta>()
            .Property(v => v.TotalFinal)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Devolucion>()
            .Property(d => d.MontoReintegrado)
            .HasPrecision(18, 2);
    }
}
