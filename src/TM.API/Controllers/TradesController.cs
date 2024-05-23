using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TM.API.Helpers;
using TM.Application.Common.Models.Trades;
using TM.Application.Trades.Commands;
using TM.Application.Trades.Queries;

namespace TM.API.Controllers
{
    [ApiController]
    [Route(""), Authorize]
    public class TradesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("trades")]
        public async Task<IActionResult> GetAllTrades()
        {
            var query = new GetAllTradesQuery()
            {
                CurrentUser = User
            };

            var trades = await _mediator.Send(query);

            return ResponseHelper.HandleResponse(trades);
        }

        [HttpGet("trades/{tradeId}")]
        public async Task<IActionResult> GetTradeById(string tradeId)
        {
            var query = new GetTradeByIdQuery(tradeId)
            {
                CurrentUser = User
            };

            var trade = await _mediator.Send(query);

            return ResponseHelper.HandleResponse(trade);
        }

        [HttpPost("trades")]
        public async Task<IActionResult> CreateTrade([FromBody] CreateTradeRequest trade)
        {
            var command = new CreateTradeCommand(trade)
            {
                CurrentUser = User
            };

            var createdTrade = await _mediator.Send(command);

            return ResponseHelper.HandleResponse(createdTrade);
        }

        [HttpPut("trades")]
        public async Task<IActionResult> UpdateTrade([FromBody] UpdateTradeRequest trade)
        {
            var command = new UpdateTradeCommand(trade)
            {
                CurrentUser = User
            };

            var updatedTrade = await _mediator.Send(command);

            return ResponseHelper.HandleResponse(updatedTrade);
        }

        [HttpDelete("trades/{tradeId}")]
        public async Task<IActionResult> DeleteTrade(string tradeId)
        {
            var command = new DeleteTradeCommand(tradeId)
            {
                CurrentUser = User
            };

            var deletedTrade = await _mediator.Send(command);

            return ResponseHelper.HandleResponse(deletedTrade);
        }

    }
}
