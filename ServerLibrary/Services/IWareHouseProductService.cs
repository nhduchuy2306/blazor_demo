using ServerLibrary.Dtos;

namespace ServerLibrary.Services;

public interface IWarehouseProductService
{
    WarehouseProductDTO GetById(int productId, int warehouseId);
    
    IEnumerable<WarehouseProductDTO> GetAll();
    
    void Delete(int productId, int warehouseId);
    
    void Update(int productId, int warehouseId, WarehouseProductInputDTO warehouseProduct);
    
    void Create(WarehouseProductInputDTO warehouseProduct);
    
    IEnumerable<WarehouseProductDTO> GetWarehousesByProductId(int productId);
    
    IEnumerable<WarehouseProductDTO> GetProductsByWarehouseId(int warehouseId);
}