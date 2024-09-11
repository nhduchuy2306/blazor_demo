using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Mappers
{
    public class WarehouseProductMapper : Profile
    {
        public WarehouseProductMapper()
        {
            CreateMap<WarehouseProduct, WarehouseProductDTO>()
                .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.WarehouseName))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ReverseMap()
                .ForMember(dest => dest.Warehouse, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());
            CreateMap<WarehouseProduct, WarehouseProductInputDTO>();
        }
    }
}
