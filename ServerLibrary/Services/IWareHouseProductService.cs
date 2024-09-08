using ServerLibrary.Dtos;

public interface IWarehouseProductService
{
    WarehouseProductDTO GetById(int productId, int warehouseId);
    IEnumerable<WarehouseProductDTO> GetAll();
    void Delete(int productId, int warehouseId);
    void Update(int productId, int warehouseId, WarehouseProductInputDTO warehouseProduct);
    void Create(WarehouseProductInputDTO warehouseProduct);
}