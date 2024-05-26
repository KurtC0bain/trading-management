using AutoMapper;
using TM.Application.Common.Models.Assets;
using TM.Application.Common.Models.Trades;
using TM.Domain.Entities;

namespace TM.Application.MapperProfiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<AssetRate, AssetRateResponse>()
                .ForMember(x => x.AssetName, opt => opt.MapFrom(x => x.AssetName))
                .ForMember(x => x.LastPrice, opt => opt.MapFrom(x => x.LastPrice))
                .ForMember(x => x.HighPrice, opt => opt.MapFrom(x => x.HighPrice))
                .ForMember(x => x.LowPrice, opt => opt.MapFrom(x => x.LowPrice))
                .ForMember(x => x.Volume, opt => opt.MapFrom(x => x.Volume))
                .ForMember(x => x.WeightedAveragePrice, opt => opt.MapFrom(x => x.WeightedAveragePrice))
                .ReverseMap();


        }
    }

}
