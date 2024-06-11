import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { Trade } from '../types/trade.interface';
import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { AssetRateResponse } from '../types/asset-rate.interface';
import { CreateTradeRequest } from '../types/create-trade.interface';
import { UpdateTradeRequest } from '../types/update-trade.interface';

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

    CreateTrade: props<{ trade: CreateTradeRequest }>(),
    'CreateTrade Success': props<{ response: Trade }>(),
    'CreateTrade Failure': props<{ errors: ErrorResponse }>(),

    UpdateTrade: props<{ trade: UpdateTradeRequest }>(),
    'UpdateTrade Success': props<{ response: Trade }>(),
    'UpdateTrade Failure': props<{ errors: ErrorResponse }>(),

    GetAssetsRates: props<{ tickerNames: string[] }>(),
    'GetAssetsRates Success': props<{ response: AssetRateResponse[] }>(),
    'GetAssetsRates Failure': props<{ errors: ErrorResponse }>(),
  },
});
