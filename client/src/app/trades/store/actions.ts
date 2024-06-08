import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { Trade } from '../types/trade.interface';
import { ErrorResponse } from '../../shared/types/errorResponse.interface';

export const tradeActions = createActionGroup({
  source: 'trades',
  events: {
    GetAllTrades: emptyProps(),
    'GetAllTrades Success': props<{ response: Trade[] }>(),
    'GetAllTrades Failure': props<{ errors: ErrorResponse }>(),

    GetTradeById: props<{ tradeId: string }>(),
    'GetTradeById Success': props<{ response: Trade }>(),
    'GetTradeById Failure': props<{ errors: ErrorResponse }>(),

    DeleteTrade: props<{ tradeId: string }>(),
    'DeleteTrade Success': props<{ response: Trade }>(),
    'DeleteTrade Failure': props<{ errors: ErrorResponse }>(),
  },
});
