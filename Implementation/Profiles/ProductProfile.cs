using Application.DataTransfer;
using AutoMapper;
using Domain;

namespace Implementation.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Size, SizeDTO>();

            CreateMap<SizeProduct, SizeProductDTO>();
            CreateMap<Category, CategoryDTO>();

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(x => x.Sizes, opt => opt.MapFrom(x => x.SizeProducts.Select(sp => sp.Size)));

            CreateMap<Product, ProductCreateDTO>();
            CreateMap<ProductCreateDTO, Product>();

            CreateMap<Product, ProductEditDTO>();
            CreateMap<ProductEditDTO, Product>();
        }
    }
}
