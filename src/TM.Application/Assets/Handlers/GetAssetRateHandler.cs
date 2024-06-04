using AutoMapper;
using MediatR;
using TM.Application.Assets.Queries;
using TM.Application.Common.Interfaces;
using TM.Application.Common.Models.Assets;
using TM.Application.Error.Models;

namespace TM.Application.Assets.Handlers
{
    public class GetAssetRateHandler(IAssetsService assetsService, IMapper mapper) : IRequestHandler<GetAssetRateQuery, Result<InternalError, AssetRateResponse>>
    {
        private readonly IAssetsService _assetsService = assetsService;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<InternalError, AssetRateResponse>> Handle(GetAssetRateQuery request, CancellationToken cancellationToken)
        {
            var assetInfo = await _assetsService.GetAssetRateAsync(request.TickerName);
            if (assetInfo == null)
                return new NotFoundError(request.TickerName);
            if (!assetInfo.IsSuccess)
                return new Result<InternalError, AssetRateResponse>(assetInfo?.Error);

            return _mapper.Map<AssetRateResponse>(assetInfo.Value);
        }
    }

}
