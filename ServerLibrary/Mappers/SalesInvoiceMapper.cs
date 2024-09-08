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
            CreateMap<SalesInvoice, SalesInvoiceDTO>().ReverseMap();
            CreateMap<SalesInvoice, SalesInvoiceInputDTO>().ReverseMap();
        }
    }
}
