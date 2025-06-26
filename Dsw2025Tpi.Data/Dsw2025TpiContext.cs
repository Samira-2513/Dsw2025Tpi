using Microsoft.EntityFrameworkCore;
using Dsw2025Tpi.Domain.Entities;
using Microsoft.Identity.Client;
namespace Dsw2025Tpi.Data;

public class Dsw2025TpiContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public Dsw2025TpiContext(DbContextOptions<Dsw2025TpiContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        base.OnModelCreating(modelBuilder);

        // <-- Pega aquí el bloque de configuración de Product -->
        modelBuilder.Entity<Product>(b =>
        {
            b.HasKey(p => p.Id);

            // SKU obligatorio y único
            b.Property(p => p.Sku)
             .IsRequired()
             .HasMaxLength(50);
            b.HasIndex(p => p.Sku)
             .IsUnique();

            // Nombre obligatorio
            b.Property(p => p.Name)
             .IsRequired()
             .HasMaxLength(100);

            // Precio unitario obligatorio y precisión
            b.Property(p => p.Price)
             .IsRequired()
             .HasColumnType("decimal(18,2)");

            // Stock obligatorio
            b.Property(p => p.Stock)
             .IsRequired();

            // IsActive
            b.Property(p => p.IsActive)
             .IsRequired();
        });

        modelBuilder.Entity<Customer>(b =>
        {
            b.HasKey(c => c.Id);
            b.Property(c => c.Name)
             .IsRequired()
             .HasMaxLength(100);
            b.Property(c => c.Email)
             .IsRequired()
             .HasMaxLength(150);
        });
    }
}