using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TM.API.Helpers;
using TM.Application.Common.Models;
using TM.Application.Error.Models;
using TM.Application.Trades.Commands;
using TM.Application.Trades.Queries;
using TM.Domain.Entities;

namespace TM.API.Controllers
{
    [ApiController]
    public class TradesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("trades")]
        public async Task<IActionResult> GetAllTrades()
        {
            var query = new GetAllTradesQuery();

            var trades = await _mediator.Send(query);

            return ResponseHelper.HandleResponse(trades);
        }

        [HttpGet("trades/{tradeId}")]
        public async Task<IActionResult> GetTradeById(string tradeId)
        {
            var query = new GetTradeByIdQuery(tradeId);

            var trade = await _mediator.Send(query);

            return ResponseHelper.HandleResponse(trade);
        }

        [HttpPost("trades")]
        public async Task<IActionResult> CreateTrade([FromBody] TradeDTO trade)
        {
            var command = new CreateTradeCommand(trade);

            var result = await _mediator.Send(command);

            return ResponseHelper.HandleResponse(result);
        }

        [HttpPut("trades")]
        public async Task<IActionResult> UpdateTrade([FromBody] TradeDTO trade)
        {
            var command = new UpdateTradeCommand(trade);

            var updatedTrade = await _mediator.Send(command);

            return updatedTrade is not null ? Ok(updatedTrade) : NotFound();
        }

        [HttpDelete("trades/{tradeId}")]
        public async Task<IActionResult> DeleteTrade(string tradeId)
        {
            var command = new DeleteTradeCommand(tradeId);

            await _mediator.Send(command);

            return Ok();
        }

    }
}
