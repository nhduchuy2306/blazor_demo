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
}
