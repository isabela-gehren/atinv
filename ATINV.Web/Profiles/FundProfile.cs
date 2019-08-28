using ATINV.Model;
using ATINV.ViewModel;
using AutoMapper;

namespace ATINV.Web.Profiles
{
    public class FundProfile : Profile
    {
        public FundProfile()
        {
            CreateMap<Fund, FundViewModel>()
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => string.Format("99.999.999/9999-99", src.Cnpj)));
        }
    }
}
