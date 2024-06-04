using AutoMapper;
using TM.Application.Common.Helpers;
using TM.Application.Common.Models;
using TM.Application.Common.Models.Trades;
using TM.Domain.Entities;

namespace TM.Application.MapperProfiles
{
    public class TradeProfile : Profile
    {
        public TradeProfile()
        {
            CreateMap<CreateTradeRequest, Trade>().
                ForMember(x => x.SetupID, opt => opt.MapFrom(q => q.SetupID)).
                ForMember(x => x.PairID, opt => opt.MapFrom(q => q.PairID)).
                ForMember(x => x.UserID, opt => opt.MapFrom(q => q.UserID)).

                ForMember(x => x.InitialDeposit, opt => opt.MapFrom(q => q.InitialDeposit)).
                ForMember(x => x.PriceTake, opt => opt.MapFrom(q => q.PriceTake)).
                ForMember(x => x.PriceEntry, opt => opt.MapFrom(q => q.PriceEntry)).
                ForMember(x => x.PriceStop, opt => opt.MapFrom(q => q.PriceStop)).
                ForMember(x => x.DepositRisk, opt => opt.MapFrom(q => q.DepositRisk)).

                ForMember(x => x.PositionType, opt => opt.MapFrom(q => q.PositionType)).
                ForMember(x => x.DirectionType, opt => opt.MapFrom(q => q.DirectionType)).
                //ForMember(x => x.ResultType, opt => opt.MapFrom(q => q.ResultType)).

                ForMember(x => x.Date, opt => opt.MapFrom(q => q.Date)).
                //ForMember(x => x.Profit, opt => opt.MapFrom(q => q.Profit)).
                //ForMember(x => x.RiskRewardRatio, opt => opt.MapFrom(q => q.RiskRewardRatio)).
                ForMember(x => x.Rating, opt => opt.MapFrom(q => q.Rating));


            CreateMap<UpdateTradeRequest, Trade>().
            ForMember(x => x.SetupID, opt => opt.MapFrom(q => q.SetupID)).
            ForMember(x => x.PairID, opt => opt.MapFrom(q => q.PairID)).
            ForMember(x => x.UserID, opt => opt.MapFrom(q => q.UserID)).

            ForMember(x => x.InitialDeposit, opt => opt.MapFrom(q => q.InitialDeposit)).
            ForMember(x => x.PriceTake, opt => opt.MapFrom(q => q.PriceTake)).
            ForMember(x => x.PriceEntry, opt => opt.MapFrom(q => q.PriceEntry)).
            ForMember(x => x.PriceStop, opt => opt.MapFrom(q => q.PriceStop)).
            ForMember(x => x.DepositRisk, opt => opt.MapFrom(q => q.DepositRisk)).

            ForMember(x => x.PositionType, opt => opt.MapFrom(q => q.PositionType)).
            ForMember(x => x.DirectionType, opt => opt.MapFrom(q => q.DirectionType)).
            ForMember(x => x.ResultType, opt => opt.MapFrom(q => q.ResultType)).

            ForMember(x => x.Date, opt => opt.MapFrom(q => q.Date)).
            //ForMember(x => x.Profit, opt => opt.MapFrom(q => q.Profit)).
            //ForMember(x => x.RiskRewardRatio, opt => opt.MapFrom(q => q.RiskRewardRatio)).
            ForMember(x => x.Rating, opt => opt.MapFrom(q => q.Rating));



            CreateMap<Trade, TradeResponse>().
            ForMember(x => x.SetupID, opt => opt.MapFrom(q => q.SetupID)).
            ForMember(x => x.PairID, opt => opt.MapFrom(q => q.PairID)).
            ForMember(x => x.UserID, opt => opt.MapFrom(q => q.UserID)).

            ForMember(x => x.InitialDeposit, opt => opt.MapFrom(q => q.InitialDeposit)).
            ForMember(x => x.PriceTake, opt => opt.MapFrom(q => q.PriceTake)).
            ForMember(x => x.PriceEntry, opt => opt.MapFrom(q => q.PriceEntry)).
            ForMember(x => x.PriceStop, opt => opt.MapFrom(q => q.PriceStop)).
            ForMember(x => x.DepositRisk, opt => opt.MapFrom(q => q.DepositRisk)).

            ForMember(x => x.PositionType, opt => opt.MapFrom(q => q.PositionType)).
            ForMember(x => x.DirectionType, opt => opt.MapFrom(q => q.DirectionType)).
            ForMember(x => x.ResultType, opt => opt.MapFrom(q => q.ResultType)).

            ForMember(x => x.Date, opt => opt.MapFrom(q => q.Date)).
            ForMember(x => x.Profit, opt => opt.MapFrom(q => q.Profit)).
            ForMember(x => x.RiskRewardRatio, opt => opt.MapFrom(q => q.RiskRewardRatio)).
            ForMember(x => x.Rating, opt => opt.MapFrom(q => q.Rating));
        }
    }
}
