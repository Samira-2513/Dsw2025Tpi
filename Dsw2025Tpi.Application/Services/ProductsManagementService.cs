using Dsw2025Tpi.Application.Dtos;
using Dsw2025Tpi.Data;
using Dsw2025Tpi.Domain.Entities;
using Dsw2025Tpi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Application.Services
{

    public class ProductsManagementService
    {
        private readonly IRepository _repo;

        public ProductsManagementService(IRepository repo)
        {
            _repo = repo;
        }

        //Ferchoooo
        public async Task<IEnumerable<Product>?> GetProducts()
        {
            return await _repo.GetAll<Product>();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            return await _repo.GetById<Product>(id);
        }

        public async Task<Response> AddProduct(Request request)
        {
            // 1. Validación de los campos obligatorios
            if (string.IsNullOrWhiteSpace(request.Sku) ||
                string.IsNullOrWhiteSpace(request.Name) ||
                request.Price < 0)
            {
                throw new ArgumentException("Valores para el producto no válidos");
            }

            // 2. Verificar si ya existe un producto con el mismo SKU
            var existing = await _repo.First<Product>(p => p.Sku == request.Sku);
            if (existing != null)
            {
                throw new DuplicatedEntityException($"Ya existe un producto con el Sku {request.Sku}");
            }

            // 3. Crear y persistir la entidad Product
            var product = new Product(request.Sku, request.Name, request.Description, request.Price, request.Stock);
            await _repo.Add<Product>(product);

            // 4. Devolver sólo el ID en el DTO de respuesta
            return new Response(product.Id,
                product.Sku,
                product.Name,
                product.Description,
                product.Price,
                product.Stock,
                product.IsActive);
        }
        public async Task<Response> UpdateProduct(Guid id, Request request)
        {
            // 1. Validación de datos de entrada
            //ProductValidator.Validate(request.Sku, request.Name, request.Price, request.Stock);

            // 2. Obtener entidad
            var p = await _repo.GetById<Product>(id);
            if (p == null)
                throw new KeyNotFoundException($"Producto con Id '{id}' no encontrado.");

            // 3. Actualizar precio y stock
            p.ChangePrice(request.Price);
            p.AdjustStock(request.Stock - p.Stock);

            // 4. Persistir cambios
            await _repo.Update<Product>(p);

            // 5. Devolver DTO completo
            return new Response(
                p.Id,
                p.Sku,
                p.Name,
                p.Description,
                p.Price,
                p.Stock,
                p.IsActive
            );
        }
        public async Task Elimi(Product p)
        {
            p.Disable();
            await _repo.Update<Product>(p);
        }
    }
}
