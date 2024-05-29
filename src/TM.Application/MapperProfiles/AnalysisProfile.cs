using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Common.Models.Analysis;
using TM.Domain.Entities;

namespace TM.Application.MapperProfiles
{
    public class AnalysisProfile : Profile
    {
        public AnalysisProfile()
        {
            CreateMap<Setup, SetupsEfficiencyResponse>().ReverseMap();
        }
    }
}
