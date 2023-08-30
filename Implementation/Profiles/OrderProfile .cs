using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderWithLinesDTO>()
            .ForMember(dest => dest.OrderLines, opt => opt.MapFrom(src => src.OrderLines))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

            CreateMap<CreateOrderDTO, Order>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.OrderLines, opt => opt.MapFrom(src => src.OrderLines));

            CreateMap<CreateOrderLineDTO, OrderLine>();
            CreateMap<User, UserDTO>();
            CreateMap<OrderLine, OrderLineDTO>();
        }
    }
}
