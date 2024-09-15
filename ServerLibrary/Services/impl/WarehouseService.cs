using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Models;
using ServerLibrary.Repositories;

namespace ServerLibrary.Services.impl;

public class WarehouseService : IWarehouseService
{
    private readonly WarehouseRepository _warehouseRepository;
    private readonly WarehouseProductRepository _warehouseProductRepository;
    private readonly IMapper _mapper;

    public WarehouseService(WarehouseRepository warehouseRepository, IMapper mapper, WarehouseProductRepository warehouseProductRepository)
    {
        _warehouseRepository = warehouseRepository;
        _mapper = mapper;
        _warehouseProductRepository = warehouseProductRepository;
    }

    public void Create(WarehouseInputDTO warehouse)
    {
        var warehouseEntity = _mapper.Map<Warehouse>(warehouse);
        _warehouseRepository.Create(warehouseEntity);
    }

    public void Delete(int warehouseId)
    {
        var existingWarehouse = _warehouseRepository.GetById(warehouseId);
        if (existingWarehouse == null)
        {
            throw new Exception("Warehouse not found");
        }

        _warehouseRepository.Delete(existingWarehouse);
    }

    public WarehouseDTO GetById(int warehouseId)
    {
        var warehouseEntity = _warehouseRepository.GetById(warehouseId);
        if (warehouseEntity == null)
        {
            throw new Exception("Warehouse not found");
        }
        return _mapper.Map<WarehouseDTO>(warehouseEntity);
    }

    public WarehouseDTO GetByName(string warehouseName)
    {
        var warehouseEntity = _warehouseRepository.GetByName(warehouseName);
        if (warehouseEntity == null)
        {
            throw new Exception("Warehouse not found");
        }
        return _mapper.Map<WarehouseDTO>(warehouseEntity);
    }

    public IEnumerable<WarehouseDTO> GetAll()
    {
        var warehouseEntities = _warehouseRepository.GetAll();
        return _mapper.Map<IEnumerable<WarehouseDTO>>(warehouseEntities);
    }

    public void Update(int warehouseId, WarehouseInputDTO warehouse)
    {
        var existingWarehouse = _warehouseRepository.GetById(warehouseId);
        if (existingWarehouse == null)
        {
            throw new Exception("Warehouse not found");
        }

        var warehouseEntity = _mapper.Map<Warehouse>(warehouse);
        warehouseEntity.WarehouseId = warehouseId;
        _warehouseRepository.Update(warehouseEntity);
    }
}