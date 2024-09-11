using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Models;

namespace ServerLibrary.Mappers
{
    public class InvoiceDetailMapper : Profile
    {
        public InvoiceDetailMapper()
        {
            CreateMap<InvoiceDetail, InvoiceDetailDTO>()
                .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.WarehouseProduct.Warehouse.WarehouseName))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.WarehouseProduct.Product.ProductName))
                .ReverseMap()
                .ForMember(dest => dest.WarehouseProduct, opt => opt.Ignore());
            CreateMap<InvoiceDetail, InvoiceDetailInputDTO>().ReverseMap();
        }
    }
}
