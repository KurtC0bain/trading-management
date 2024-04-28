using MediatR;
using Microsoft.AspNetCore.Mvc;
using TM.Application.Common.Models;
using TM.Application.Trades.Commands;
using TM.Application.Trades.Queries;
using TM.Application.Validation;

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

            return Ok(trades);
        }

        [HttpGet("trades/{tradeId}")]
        public async Task<IActionResult> GetTradeById(string tradeId)
        {
            var query = new GetTradeByIdQuery(tradeId);

            var trade = await _mediator.Send(query);

            return trade is not null ? Ok(trade) : NotFound();
        }

        [HttpPost("trades")]
        public async Task<IActionResult> CreateTrade([FromBody]TradeDTO trade)
        {
            var command = new CreateTradeCommand(trade, "test");

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("trades")]
        public async Task<IActionResult> UpdateTrade([FromBody] TradeDTO trade)
        {
            var command = new UpdateTradeCommand(trade);

            await _mediator.Send(command);

            return trade is not null ? Ok(trade) : NotFound();
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
