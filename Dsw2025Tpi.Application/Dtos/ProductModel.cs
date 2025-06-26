
namespace Dsw2025Tpi.Application.Dtos
{
    public record Response(
         Guid Id,
         string Sku,
         string Name,
         string Description,
         decimal Price,
         int Stock,
         bool IsActive
     );
    public record Request(
        string Sku,
        string Name,
        string Description,
        decimal Price,
        int Stock
    );
}
