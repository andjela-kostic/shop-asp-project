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
    public class SizeProductProfile : Profile
    {
        public SizeProductProfile()
        {
            CreateMap<SizeProduct, SizeProductDTO>()
                .ForMember(dto => dto.OrderLinesCount, opt => opt.MapFrom(sp => sp.OrderLines.Count));

            CreateMap<SizeProduct, DeleteSizeProductDTO>();
            CreateMap<DeleteSizeProductDTO, SizeProduct>();
        }
    }
}
