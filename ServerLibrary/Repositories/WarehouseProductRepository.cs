using ServerLibrary.Models;

namespace ServerLibrary.Repositories
{
    public class WarehouseProductRepository : AbstractRepository<WarehouseProduct, int>
    {
        public WarehouseProductRepository(ManagementdbContext context) : base(context)
        {
        }

        public WarehouseProduct? GetById(int warehouseId, int productId)
        {
            return _context.WarehouseProducts.SingleOrDefault(whp => whp.WarehouseId == warehouseId && whp.ProductId == productId);
        }
    }
}
