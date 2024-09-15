using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Models;

namespace ServerLibrary.Mappers;

public class CustomerMapper : Profile
{
    public CustomerMapper()
    {
        CreateMap<Customer, CustomerDTO>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
            .ReverseMap()
            .ForMember(dest => dest.Role, opt => opt.Ignore());

        CreateMap<Customer, CustomerInputDTO>().ReverseMap();
    }
}
