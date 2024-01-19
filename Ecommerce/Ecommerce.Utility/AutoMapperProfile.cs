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
            CreateMap<User, UserDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdUser))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameUser))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailUser))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordUser))
            .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.RolUser))
            .ReverseMap(); 

            CreateMap<User, SessionDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdUser))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameUser))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailUser))
            .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.RolUser))
            .ReverseMap();


            //Map para Categoria
            CreateMap<Category, CategotyDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdCategory))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameCategory))
                .ReverseMap();
    

            //Map para producto
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdProduct))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameProduct))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.DescriptionProduct))
                .ForMember(dest => dest.IdCategory, opt => opt.MapFrom(src => src.IdCategory))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PriceProduct))
                .ForMember(dest => dest.OfferPrice, opt => opt.MapFrom(src => src.OfferPriceProduct))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.QuantityProduct))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageProduct))
                .ReverseMap();

            //Excepcion 
            /*  CreateMap<ProductDTO, Product>()
                  .ForMember(des => des.IdCategoryNavigation,opt => opt.Ignore())
                  .ForMember(des => des.CreatedDateProduct,opt => opt.Ignore());*/



            //Map para detalleVenta
            CreateMap<DetailsSale, DetailsSaleDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdDetailSale))
            .ForMember(dest => dest.IdProduct, opt => opt.MapFrom(src => src.IdProduct))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.QuantityProduct))
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.TotalProduct));

            CreateMap<DetailsSaleDTO, DetailsSale>()
                .ForMember(dest => dest.IdDetailSale, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdProduct, opt => opt.MapFrom(src => src.IdProduct))
                .ForMember(dest => dest.QuantityProduct, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.TotalProduct, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.IdSale, opt => opt.Ignore())
                .ForMember(dest => dest.IdProductNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdSaleNavigation, opt => opt.Ignore());


          
            //Map para Venta
            CreateMap<Sale, SaleDTO>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdSale))
                 .ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.IdUser))
                 .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.TotalSale))
                 .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDateSale));

            CreateMap<SaleDTO, Sale>()
                .ForMember(dest => dest.IdSale, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.IdUser))
                .ForMember(dest => dest.TotalSale, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.CreatedDateSale, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.IdUserNavigation, opt => opt.Ignore());



        }
    }
}
