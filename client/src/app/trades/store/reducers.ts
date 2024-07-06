import { createFeature, createReducer, on } from '@ngrx/store';
import { TradesStateInterface } from '../types/tradesState.interface';
import { tradeActions } from './actions';

const initialState: TradesStateInterface = {
  isLoading: false,
  isAssetsLoading: false,
  isPairsLoading: false,
  errors: null,
  trades: null,
  trade: null,
  assets: null,
  pairs: null,
};

export const tradeFeature = createFeature({
  name: 'trades',
  reducer: createReducer(
    initialState,
    on(tradeActions.getAllTrades, (state) => ({
      ...state,
      isLoading: true,
      errors: null,
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

    on(tradeActions.createTrade, (state) => ({
      ...state,
      isLoading: true,
      errors: null,
    })),
    on(tradeActions.createTradeSuccess, (state, action) => ({
      ...state,
      isLoading: false,
      errors: null,
      trade: action.response,
    })),
    on(tradeActions.createTradeFailure, (state, action) => ({
      ...state,
      isLoading: false,
      errors: action.errors,
    })),

    on(tradeActions.updateTrade, (state) => ({
      ...state,
      isLoading: true,
      errors: null,
    })),
    on(tradeActions.updateTradeSuccess, (state, action) => ({
      ...state,
      isLoading: false,
      errors: null,
      trade: action.response,
    })),
    on(tradeActions.updateTradeFailure, (state, action) => ({
      ...state,
      isLoading: false,
      errors: action.errors,
    })),

    on(tradeActions.getAllPairs, (state) => ({
      ...state,
      isPairsLoading: true,
      errors: null,
    })),
    on(tradeActions.getAllPairsSuccess, (state, action) => ({
      ...state,
      isPairsLoading: false,
      errors: null,
      pairs: action.response,
    })),
    on(tradeActions.getAllPairsFailure, (state, action) => ({
      ...state,
      isPairsLoading: false,
      errors: action.errors,
    })),

    on(tradeActions.getAssetsRates, (state) => ({
      ...state,
      isAssetsLoading: true,
      errors: null,
    })),
    on(tradeActions.getAssetsRatesSuccess, (state, action) => ({
      ...state,
      isAssetsLoading: false,
      errors: null,
      assets: action.response,
    })),
    on(tradeActions.getAssetsRatesFailure, (state, action) => ({
      ...state,
      isAssetsLoading: false,
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
  selectIsAssetsLoading,
  selectPairs,
  selectIsPairsLoading,
} = tradeFeature;
