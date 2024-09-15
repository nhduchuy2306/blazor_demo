using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Models;

namespace ServerLibrary.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();

        CreateMap<Product, ProductInputDTO>().ReverseMap();

        CreateMap<Product, ProductUpdateDTO>().ReverseMap()
            .ForMember(dest => dest.ProductId, opt => opt.Ignore());
    }
}
