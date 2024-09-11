using Microsoft.EntityFrameworkCore;
using ServerLibrary.Models;

namespace ServerLibrary.Repositories
{
    public class WarehouseProductRepository : Repository<WarehouseProduct, int>
    {
        public WarehouseProductRepository(ManagementdbContext context) : base(context)
        {
        }

        public WarehouseProduct? GetById(int warehouseId, int productId)
        {
            return _context.WarehouseProducts.SingleOrDefault(whp => whp.WarehouseId == warehouseId && whp.ProductId == productId);
        }

        public IEnumerable<WarehouseProduct> GetWarehousesByProductId(int productId)
        {
            return _context.WarehouseProducts
                .Include(whp => whp.Warehouse)
                .Include(whp => whp.Product)
                .Where(whp => whp.ProductId == productId)
                .ToList();
        }

        public IEnumerable<WarehouseProduct> GetProductsByWarehouseId(int warehouseId)
        {
            return _context.WarehouseProducts
                .Include(whp => whp.Warehouse)
                .Include(whp => whp.Product)
                .Where(whp => whp.WarehouseId == warehouseId)
                .ToList();
        }
    }
}
