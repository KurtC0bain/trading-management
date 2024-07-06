using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TM.API.Helpers;
using TM.Application.Analysis.Queries;
using TM.Domain.Entities;

namespace TM.API.Controllers
{
    [Route("")]
    [ApiController]
    [Authorize]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("setup-efficiency")]
        public async Task<IActionResult> GetSetupEfficiency()
        {
            var query = new GetSetupsEfficiencyQuery(User);
            var result = await _mediator.Send(query);
            return ResponseHelper.HandleResponse(result);
        }

        [HttpGet("assets-income")]
        public async Task<IActionResult> GetAssetsIncome()
        {
            var query = new GetAssetsIncomeQuery(User);
            var result = await _mediator.Send(query);
            return ResponseHelper.HandleResponse(result);
        }
    }
}
