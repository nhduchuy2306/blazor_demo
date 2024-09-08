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
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductInputDTO>().ReverseMap();
        }
    }
}
