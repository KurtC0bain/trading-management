using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TM.API.Helpers;
using TM.Application.Common.Models.Factors;
using TM.Application.Factors.Commands;
using TM.Application.Factors.Queries;

namespace TM.API.Controllers
{
    [ApiController]
    [Route("")]
    [Authorize]
    public class FactorsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("factors")]
        public async Task<IActionResult> GetAllFactors()
        {
            var query = new GetAllFactorsQuery(User);

            var factors = await _mediator.Send(query);

            return ResponseHelper.HandleResponse(factors);
        }

        [HttpGet("factors/{factorId}")]
        public async Task<IActionResult> GetFactorById(string factorId)
        {
            var query = new GetFactorByIdQuery(factorId, User);

            var factor = await _mediator.Send(query);

            return ResponseHelper.HandleResponse(factor);
        }

        [HttpPost("factors")]
        public async Task<IActionResult> CreateFactor([FromBody] FactorRequest factor)
        {
            var command = new CreateFactorCommand(factor, User);

            var createdFactor = await _mediator.Send(command);

            return ResponseHelper.HandleResponse(createdFactor);
        }

        [HttpPut("factors")]
        public async Task<IActionResult> UpdateFactor([FromBody] FactorRequest factor, string factorId)
        {
            var command = new UpdateFactorCommand(factor, factorId, User);

            var updatedFactor = await _mediator.Send(command);

            return ResponseHelper.HandleResponse(updatedFactor);
        }

        [HttpDelete("factors/{factorId}")]
        public async Task<IActionResult> DeleteFactor(string factorId)
        {
            var command = new DeleteFactorCommand(factorId, User);

            var deletedFactor = await _mediator.Send(command);

            return ResponseHelper.HandleResponse(deletedFactor);
        }

    }

}
