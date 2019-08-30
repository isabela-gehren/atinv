using ATINV.Model;
using ATINV.ViewModel;
using AutoMapper;
using System;

namespace ATINV.Web.Profiles
{
    public class MovimentProfile : Profile
    {
        public MovimentProfile()
        {
            CreateMap<Moviment, MovimentViewModel>()
                .ForMember(dest => dest.MovimentType, opt => opt.MapFrom(src => src.MovimentType.ToString()))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => Convert.ToUInt64(src.Cpf).ToString(@"000\.000\.000\-00")))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd")));

            CreateMap<MovimentViewModel, Moviment>()
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf.Replace(".", "").Replace("-", "")));
        }
    }
}
