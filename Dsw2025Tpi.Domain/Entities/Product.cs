using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Sku { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public bool IsActive { get; private set; }

        private Product() { }

        // Constructor para crear un producto nuevo
        public Product(string sku, string name, string description, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(sku))
                throw new ArgumentException("El SKU es obligatorio.", nameof(sku));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre es obligatorio.", nameof(name));
            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), "El precio debe ser mayor a 0.");
            if (stock < 0)
                throw new ArgumentOutOfRangeException(nameof(stock), "El stock no puede ser negativo.");

            Sku = sku;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            IsActive = true;
        }

        // Métodos de dominio
        public void Disable() => IsActive = false;

        public void ChangePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice), "El precio debe ser mayor a 0.");
            Price = newPrice;
        }

        public void AdjustStock(int delta)
        {
            if (Stock + delta < 0)
                throw new InvalidOperationException("Stock insuficiente para la operación.");
            Stock += delta;
        }
    }
}
