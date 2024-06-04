using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TM.API.Helpers;
using TM.Application.Common.Models.Pairs;
using TM.Application.Pairs.Commands;
using TM.Application.Pairs.Queries;

namespace TM.API.Controllers
{
    [ApiController]
    [Route("")]
    public class PairsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("pairs")]
        public async Task<IActionResult> GetAllPairs()
        {
            var query = new GetAllPairsQuery();

            var pairs = await _mediator.Send(query);

            return ResponseHelper.HandleResponse(pairs);
        }

        [HttpGet("pairs/{pairId}")]
        public async Task<IActionResult> GetPairById(string pairId)
        {
            var query = new GetPairByIdQuery(pairId);

            var pair = await _mediator.Send(query);

            return ResponseHelper.HandleResponse(pair);
        }

        [HttpPost("pairs")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePair([FromBody] PairRequest pair)
        {
            var command = new CreatePairCommand(pair);

            var createdPair = await _mediator.Send(command);

            return ResponseHelper.HandleResponse(createdPair);
        }

        [HttpPut("pairs")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePair([FromBody] PairRequest pair, string pairId)
        {
            var command = new UpdatePairCommand(pair, pairId);

            var updatedPair = await _mediator.Send(command);

            return ResponseHelper.HandleResponse(updatedPair);
        }

        [HttpDelete("pairs/{pairId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePair(string pairId)
        {
            var command = new DeletePairCommand(pairId);

            var deletedPair = await _mediator.Send(command);

            return ResponseHelper.HandleResponse(deletedPair);
        }

    }

}
