using MediatR;
using TM.Application.Common.Models.Assets;
using TM.Application.Error.Models;

namespace TM.Application.Assets.Queries
{
    public class GetAssetRateQuery(string tickerName) : IRequest<Result<InternalError, AssetRateResponse>>
    {
        public string TickerName { get; } = tickerName;
    }
}
