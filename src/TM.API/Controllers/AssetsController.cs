using MediatR;
using Microsoft.AspNetCore.Mvc;
using TM.API.Helpers;
using TM.Application.Assets.Queries;

namespace TM.API.Controllers
{
    [ApiController]
    [Route("")]
    public class AssetsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("rate/{tickerName}")]
        public async Task<IActionResult> GetAssetRateByTickerName(string tickerName)
        {
            var query = new GetAssetRateQuery(tickerName);

            var assetInfo = await _mediator.Send(query);

            return ResponseHelper.HandleResponse(assetInfo);
        }
    }
}
