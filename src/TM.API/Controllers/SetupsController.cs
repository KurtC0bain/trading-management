using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TM.API.Helpers;
using TM.Application.Common.Models.Setups;
using TM.Application.Setups.Commands;
using TM.Application.Setups.Queries;

namespace TM.API.Controllers
{
    [ApiController]
    [Route("")]
    [Authorize]
    public class SetupsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("setups")]
        public async Task<IActionResult> GetAllSetups()
        {
            var query = new GetAllSetupsQuery(User);

            var setups = await _mediator.Send(query);

            return ResponseHelper.HandleResponse(setups);
        }

        [HttpGet("setups/{setupId}")]
        public async Task<IActionResult> GetSetupById(string setupId)
        {
            var query = new GetSetupByIdQuery(setupId, User);

            var setup = await _mediator.Send(query);

            return ResponseHelper.HandleResponse(setup);
        }

        [HttpPost("setups")]
        public async Task<IActionResult> CreateSetup([FromBody] SetupRequest setup)
        {
            var command = new CreateSetupCommand(setup, User);

            var createdSetup = await _mediator.Send(command);

            return ResponseHelper.HandleResponse(createdSetup);
        }

        [HttpPut("setups")]
        public async Task<IActionResult> UpdateSetup([FromBody] SetupRequest setup, string setupId)
        {
            var command = new UpdateSetupCommand(setup, setupId, User);

            var updatedSetup = await _mediator.Send(command);

            return ResponseHelper.HandleResponse(updatedSetup);
        }

        [HttpDelete("setups/{setupId}")]
        public async Task<IActionResult> DeleteSetup(string setupId)
        {
            var command = new DeleteSetupCommand(setupId, User);

            var deletedSetup = await _mediator.Send(command);

            return ResponseHelper.HandleResponse(deletedSetup);
        }

    }

}
