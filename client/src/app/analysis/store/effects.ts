import { inject } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { AnalysisService } from '../services/analysis.service';
import { analysisActions } from './actions';
import { catchError, map, of, switchMap } from 'rxjs';
import { AssetsIncome, SetupsEfficiency } from '../types/analysis.interface';
import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { authActions } from '../../auth/store/actions';

export const getAssetsIncome = createEffect(
  (actions$ = inject(Actions), analysisService = inject(AnalysisService)) => {
    return actions$.pipe(
      ofType(analysisActions.getAssetsIncome),
      switchMap(() => {
        return analysisService.getAssetsIncome().pipe(
          map((response: AssetsIncome[]) => {
            return analysisActions.getAssetsIncomeSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }

            return of(
              analysisActions.getAssetsIncomeFailure({
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

export const getSetupsEfficiency = createEffect(
  (actions$ = inject(Actions), analysisService = inject(AnalysisService)) => {
    return actions$.pipe(
      ofType(analysisActions.getSetupsEfficiency),
      switchMap(() => {
        return analysisService.getSetupEfficiency().pipe(
          map((response: SetupsEfficiency[]) => {
            return analysisActions.getSetupsEfficiencySuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }

            return of(
              analysisActions.getSetupsEfficiencyFailure({
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
