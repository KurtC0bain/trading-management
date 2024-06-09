import { createFeature, createReducer, on } from '@ngrx/store';
import { TradesStateInterface } from '../types/tradesState.interface';
import { tradeActions } from './actions';

const initialState: TradesStateInterface = {
  isLoading: false,
  errors: null,
  trades: null,
  trade: null,
  assets: null,
};

export const tradeFeature = createFeature({
  name: 'trades',
  reducer: createReducer(
    initialState,
    on(tradeActions.getAllTrades, (state) => ({
      ...state,
      isLoading: true,
      validationErrors: null,
    })),
    on(tradeActions.getAllTradesSuccess, (state, action) => ({
      ...state,
      isLoading: false,
      errors: null,
      trades: action.response,
    })),
    on(tradeActions.getAllTradesFailure, (state, action) => ({
      ...state,
      isLoading: false,
      errors: action.errors,
    })),

    on(tradeActions.getTradeById, (state) => ({
      ...state,
      isLoading: true,
      errors: null,
    })),
    on(tradeActions.getTradeByIdSuccess, (state, action) => ({
      ...state,
      isLoading: false,
      errors: null,
      trade: action.response,
    })),
    on(tradeActions.getTradeByIdFailure, (state, action) => ({
      ...state,
      isLoading: false,
      errors: action.errors,
    })),

    on(tradeActions.deleteTrade, (state) => ({
      ...state,
      isLoading: true,
      errors: null,
    })),
    on(tradeActions.deleteTradeSuccess, (state, action) => ({
      ...state,
      isLoading: false,
      errors: null,
      trade: action.response,
    })),
    on(tradeActions.deleteTradeFailure, (state, action) => ({
      ...state,
      isLoading: false,
      errors: action.errors,
    })),

    on(tradeActions.getAssetsRates, (state) => ({
      ...state,
      isLoading: true,
      errors: null,
    })),
    on(tradeActions.getAssetsRatesSuccess, (state, action) => ({
      ...state,
      isLoading: false,
      errors: null,
      assets: action.response,
    })),
    on(tradeActions.getAssetsRatesFailure, (state, action) => ({
      ...state,
      isLoading: false,
      errors: action.errors,
    }))
  ),
});

export const {
  name: tradeFeatureKey,
  reducer: tradeReducer,
  selectTrades,
  selectIsLoading,
  selectErrors,
  selectTrade,
  selectAssets,
} = tradeFeature;
