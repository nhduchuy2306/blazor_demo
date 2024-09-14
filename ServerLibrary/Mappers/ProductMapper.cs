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
    }
}
