using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Models;
using ServerLibrary.Repositories;

public class WarehouseProductService : IWarehouseProductService
{
    private readonly WarehouseProductRepository _warehouseProductRepository;
    private readonly IMapper _mapper;

    public WarehouseProductService(WarehouseProductRepository warehouseProductRepository, IMapper mapper)
    {
        _warehouseProductRepository = warehouseProductRepository;
        _mapper = mapper;
    }

    public void Create(WarehouseProductInputDTO warehouseProductInputDTO)
    {
        var warehouseProduct = _mapper.Map<WarehouseProduct>(warehouseProductInputDTO);
        _warehouseProductRepository.Create(warehouseProduct);
    }

    public void Delete(int productId, int warehouseId)
    {
        var existingWarehouseProduct = _warehouseProductRepository.GetById(productId, warehouseId);
        if (existingWarehouseProduct == null)
        {
            throw new KeyNotFoundException($"Warehouse product with product id {productId} and warehouse id {warehouseId} not found");
        }

        _warehouseProductRepository.Delete(existingWarehouseProduct);
    }

    public IEnumerable<WarehouseProductDTO> GetAll()
    {
        var warehouseProducts = _warehouseProductRepository.GetAll();
        return _mapper.Map<IEnumerable<WarehouseProductDTO>>(warehouseProducts);
    }

    public WarehouseProductDTO GetById(int productId, int warehouseId)
    {
        var warehouseProduct = _warehouseProductRepository.GetById(productId, warehouseId);
        if (warehouseProduct == null)
        {
            throw new KeyNotFoundException($"Warehouse product with product id {productId} and warehouse id {warehouseId} not found");
        }

        return _mapper.Map<WarehouseProductDTO>(warehouseProduct);
    }

    public void Update(int productId, int warehouseId, WarehouseProductInputDTO warehouseProduct)
    {
        var existingWarehouseProduct = _warehouseProductRepository.GetById(productId, warehouseId);
        if (existingWarehouseProduct == null)
        {
            throw new KeyNotFoundException($"Warehouse product with product id {productId} and warehouse id {warehouseId} not found");
        }

        var updatedWarehouseProduct = _mapper.Map<WarehouseProduct>(warehouseProduct);
        updatedWarehouseProduct.ProductId = productId;
        updatedWarehouseProduct.WarehouseId = warehouseId;

        _warehouseProductRepository.Update(updatedWarehouseProduct);
    }
}