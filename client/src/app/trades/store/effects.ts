import { inject } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { switchMap, map, catchError, of, tap, Observable } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { PersistanceService } from '../../shared/services/persistance.service';
import { Router } from '@angular/router';
import { TradeService } from '../services/trades.service';
import { tradeActions } from './actions';
import { Trade } from '../types/trade.interface';
import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { AssetRateResponse } from '../types/asset-rate.interface';
import { authActions } from '../../auth/store/actions';

export const getTradesEffect = createEffect(
  (actions$ = inject(Actions), tradeService = inject(TradeService)) => {
    return actions$.pipe(
      ofType(tradeActions.getAllTrades, tradeActions.deleteTradeSuccess),
      switchMap(() => {
        return tradeService.getAllTrades().pipe(
          map((response: Trade[]) => {
            return tradeActions.getAllTradesSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }

            return of(
              tradeActions.getAllTradesFailure({
                errors: errorResponse,
              })
            );
          })
        );
      })
    );
  },
  { functional: true }
);

export const getTradeByIdEffect = createEffect(
  (actions$ = inject(Actions), tradeService = inject(TradeService)) => {
    return actions$.pipe(
      ofType(tradeActions.getTradeById),
      switchMap(({ tradeId }) => {
        return tradeService.getTradeById(tradeId).pipe(
          map((response: Trade) => {
            return tradeActions.getTradeByIdSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }

            return of(
              tradeActions.getTradeByIdFailure({
                errors: errorResponse,
              })
            );
          })
        );
      })
    );
  },
  { functional: true }
);

export const deleteTradeEffect = createEffect(
  (actions$ = inject(Actions), tradeService = inject(TradeService)) => {
    return actions$.pipe(
      ofType(tradeActions.deleteTrade),
      switchMap(({ tradeId }) => {
        return tradeService.deleteTrade(tradeId).pipe(
          map((response: Trade) => {
            return tradeActions.deleteTradeSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }

            return of(
              tradeActions.deleteTradeFailure({
                errors: errorResponse,
              })
            );
          })
        );
      })
    );
  },
  { functional: true }
);

export const getAssetsRatesEffect = createEffect(
  (actions$ = inject(Actions), tradeService = inject(TradeService)) => {
    return actions$.pipe(
      ofType(tradeActions.getAssetsRates),
      switchMap(({ tickerNames }) => {
        return tradeService.getAssetsRates(tickerNames).pipe(
          map((response: AssetRateResponse[]) => {
            return tradeActions.getAssetsRatesSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }

            return of(
              tradeActions.getAssetsRatesFailure({
                errors: errorResponse,
              })
            );
          })
        );
      })
    );
  },
  { functional: true }
);
