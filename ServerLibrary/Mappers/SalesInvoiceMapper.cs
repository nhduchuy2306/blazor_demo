using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Models;

namespace ServerLibrary.Mappers;

public class SalesInvoiceMapper : Profile
{
    public SalesInvoiceMapper()
    {
        CreateMap<SalesInvoice, SalesInvoiceDTO>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.CustomerName))
            .ReverseMap()
            .ForMember(dest => dest.Customer, opt => opt.Ignore());

        CreateMap<SalesInvoice, SalesInvoiceInputDTO>().ReverseMap();
    }
}
