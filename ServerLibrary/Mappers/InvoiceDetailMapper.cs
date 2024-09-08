using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Models;

namespace ServerLibrary.Mappers
{
    public class InvoiceDetailMapper : Profile
    {
        public InvoiceDetailMapper()
        {
            CreateMap<InvoiceDetail, InvoiceDetailDTO>().ReverseMap();
            CreateMap<InvoiceDetail, InvoiceDetailInputDTO>().ReverseMap();
        }
    }
}
