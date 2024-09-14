using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Models;

namespace ServerLibrary.Mappers;

public class WarehouseMapper : Profile
{
    public WarehouseMapper()
    {
        CreateMap<Warehouse, WarehouseDTO>().ReverseMap();
        CreateMap<Warehouse, WarehouseInputDTO>().ReverseMap();
    }
}
