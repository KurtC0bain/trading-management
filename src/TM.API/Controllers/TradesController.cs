using MediatR;
using Microsoft.AspNetCore.Mvc;
using TM.Application.Common.Models;
using TM.Application.Trades.Commands.CreateTrade;
using TM.Application.Trades.Commands.UpdateTrade;
using TM.Application.Trades.Queries;

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
        public async Task<IActionResult> CreateTrade(TradeDTO trade)
        {
            var query = new CreateTradeCommand(trade);

            await _mediator.Send(query);

            return trade is not null ? Ok(trade) : NotFound();
        }

        [HttpPut("trades")]
        public async Task<IActionResult> UpdateTrade(TradeDTO trade)
        {
            var query = new UpdateTradeCommand(trade);

            await _mediator.Send(query);

            return trade is not null ? Ok(trade) : NotFound();
        }

    }
}
