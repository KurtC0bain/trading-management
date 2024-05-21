using MediatR;
using TM.Application.Common.Models;
using TM.Application.Error.Models;

namespace TM.Application.Trades.Commands
{
    public class CreateTradeCommand : IRequest<Result<InternalError, TradeDTO>>
    {
        public TradeDTO TradeDTO { get; }

        public CreateTradeCommand(TradeDTO tradeDTO)
        {
            TradeDTO = tradeDTO ?? throw new ArgumentNullException(nameof(tradeDTO));
        }
    }
}
