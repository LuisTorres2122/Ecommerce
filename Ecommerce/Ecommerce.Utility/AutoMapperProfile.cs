using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Model;

namespace Ecommerce.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Map para Usuario
            CreateMap<User, UserDTO>();
            CreateMap<User, SessionDTO>();
            CreateMap<UserDTO, User>();

            //Map para Categoria
            CreateMap<Category, CategotyDTO>();
            CreateMap<CategotyDTO, Category>();

            //Map para producto
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>().ForMember(des => 
            des.IdCategoryNavigation,
            opt => opt.Ignore());

            //Map para detalleVenta
            CreateMap<DetailsSale, DetailsSaleDTO>();
            CreateMap<DetailsSaleDTO, DetailsSale>();

            //Map para Venta
            CreateMap<Sale, SaleDTO>();
            CreateMap<SaleDTO, Sale>(); 


        }
    }
}
