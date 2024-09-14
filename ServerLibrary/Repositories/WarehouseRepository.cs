using ServerLibrary.Models;

namespace ServerLibrary.Repositories;

public class WarehouseRepository : Repository<Warehouse, int>
{
    public WarehouseRepository(ManagementdbContext context) : base(context)
    {
    }

    public Warehouse? GetByName(string warehouseName)
    {
        return _context.Warehouses.SingleOrDefault(w => w.WarehouseName.Contains(warehouseName));
    }
}