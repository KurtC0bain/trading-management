﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}
