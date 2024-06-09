using MediatR;
using TM.Application.Common.Models.Assets;
using TM.Application.Error.Models;

namespace TM.Application.Assets.Queries
{
    public class GetAssetRateQuery(AssetsRatesRequest request) : IRequest<Result<InternalError, List<AssetRateResponse>>>
    {
        public AssetsRatesRequest AssetsRatesRequest { get; } = request;
    }
}
