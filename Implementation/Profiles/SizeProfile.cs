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
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<Size, SizeDTO>();
            CreateMap<SizeDTO, Size>();

            CreateMap<Size, CreateSizeDTO>();
            CreateMap<CreateSizeDTO, Size>();
        }
    }
}