using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Common.Models.Factors;
using TM.Application.Common.Models.Setups;
using TM.Domain.Entities;

namespace TM.Application.MapperProfiles
{
    public class SetupProfile : Profile
    {
        public SetupProfile()
        {
            CreateMap<Setup, SetupResponse>()
                .ForMember(x => x.ID, opt => opt.MapFrom(x => x.ID))
                .ForMember(x => x.UserID, opt => opt.MapFrom(x => x.UserID))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.Factors, opt => opt.MapFrom(src => src.Factors.Select(f => f.ID)))
                .ReverseMap();

            CreateMap<SetupRequest, Setup>()
                .ForMember(x => x.UserID, opt => opt.MapFrom(x => x.UserID))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.Factors, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}
