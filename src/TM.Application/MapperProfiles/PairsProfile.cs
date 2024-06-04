using AutoMapper;
using TM.Application.Common.Models.Pairs;
using TM.Domain.Entities;

namespace TM.Application.MapperProfiles
{
    public class PairsProfile : Profile
    {
        public PairsProfile()
        {
            CreateMap<Pair, PairResponse>()
                .ForMember(x => x.ID, opt => opt.MapFrom(x => x.ID))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ReverseMap();

            CreateMap<PairRequest, Pair>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ReverseMap();

        }

    }
}
