using Binance.Net.Clients;
using TM.Application.Common.Interfaces;
using TM.Application.Error.Models;
using TM.Domain.Entities;

namespace TM.Infrastructure.Binance.API.Services
{
    public class AssetsService : IAssetsService
    {
        public async Task<Result<InternalError, AssetRate>> GetAssetRateAsync(string tickerName)
        {
            var restClient = new BinanceRestClient();
            var tickerResult = await restClient.UsdFuturesApi.ExchangeData.GetTickerAsync(tickerName);

            if (!tickerResult.Success)
            {
                return new WrongAssetSymbolError(tickerName);
            }

            return new AssetRate
            {
                AssetName = tickerResult.Data.Symbol,
                LastPrice = tickerResult.Data.LastPrice,
                HighPrice = tickerResult.Data.HighPrice,
                LowPrice = tickerResult.Data.LowPrice,
                Volume = tickerResult.Data.Volume,
                WeightedAveragePrice = tickerResult.Data.WeightedAveragePrice
            };
        }
    }
}
