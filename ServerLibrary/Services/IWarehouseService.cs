using ServerLibrary.Dtos;

public interface IWarehouseService
{
    WarehouseDTO GetByName(string warehouseName);
    WarehouseDTO GetById(int warehouseId);
    IEnumerable<WarehouseDTO> GetAll();
    void Delete(int warehouseId);
    void Update(int warehouseId, WarehouseInputDTO warehouse);
    void Create(WarehouseInputDTO warehouse);
}