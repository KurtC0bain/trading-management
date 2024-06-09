using AutoMapper;
using MediatR;
using TM.Application.Assets.Queries;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Assets;
using TM.Application.Error.Models;

namespace TM.Application.Assets.Handlers
{
    public class GetAssetRateHandler(IAssetsService assetsService, IMapper mapper) : IRequestHandler<GetAssetRateQuery, Result<InternalError, List<AssetRateResponse>>>
    {
        private readonly IAssetsService _assetsService = assetsService;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<InternalError, List<AssetRateResponse>>> Handle(GetAssetRateQuery request, CancellationToken cancellationToken)
        {
            List<AssetRateResponse> response = new List<AssetRateResponse>();

            foreach (var tickerName in request.AssetsRatesRequest.TickerNames)
            {
                var assetInfo = await _assetsService.GetAssetRateAsync(tickerName);
                if (assetInfo == null)
                    return new NotFoundError(tickerName);
                if (!assetInfo.IsSuccess)
                    return new Result<InternalError, List<AssetRateResponse>>(assetInfo?.Error);
                response.Add(_mapper.Map<AssetRateResponse>(assetInfo.Value));
            }
            return response;
        }
    }

}
