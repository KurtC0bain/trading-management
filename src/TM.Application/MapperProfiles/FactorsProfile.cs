using AutoMapper;
using TM.Application.Common.Models.Factors;
using TM.Domain.Entities;

namespace TM.Application.MapperProfiles
{
    public class FactorsProfile : Profile
    {
        public FactorsProfile()
        {
            CreateMap<Factor, FactorResponse>()
                .ForMember(x => x.ID, opt => opt.MapFrom(x => x.ID))
                .ForMember(x => x.UserID, opt => opt.MapFrom(x => x.UserID))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.Priority, opt => opt.MapFrom(x => x.Priority))
                .ReverseMap();

            CreateMap<FactorRequest, Factor>()
                .ForMember(x => x.UserID, opt => opt.MapFrom(x => x.UserID))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.Priority, opt => opt.MapFrom(x => x.Priority))
                .ReverseMap();

        }
    }
}
