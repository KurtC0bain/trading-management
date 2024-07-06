using MediatR;
using Microsoft.AspNetCore.Mvc;
using TM.API.Helpers;
using TM.Application.Assets.Queries;
using TM.Application.Common.Models.Assets;

namespace TM.API.Controllers
{
    [ApiController]
    [Route("")]
    public class AssetsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("rate")]
        public async Task<IActionResult> GetAssetRateByTickerName(AssetsRatesRequest tickerNames)
        {
            var query = new GetAssetRateQuery(tickerNames);

            var assetInfo = await _mediator.Send(query);

            return ResponseHelper.HandleResponse(assetInfo);
        }
    }
}
