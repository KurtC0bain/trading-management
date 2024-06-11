import { inject } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { FactorService } from '../services/factor.service';
import { catchError, map, of, switchMap } from 'rxjs';
import { factorActions } from './actions';
import { Factor } from '../types/factor.interface';
import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { authActions } from '../../auth/store/actions';

export const getFactorsEffect = createEffect(
  (actions$ = inject(Actions), factorService = inject(FactorService)) => {
    return actions$.pipe(
      ofType(
        factorActions.getAllFactors,
        factorActions.deleteFactorSuccess,
        factorActions.createFactorSuccess,
        factorActions.updateFactorSuccess
      ),
      switchMap(() => {
        return factorService.getAllFactors().pipe(
          map((response: Factor[]) => {
            return factorActions.getAllFactorsSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }

            return of(
              factorActions.getAllFactorsFailure({
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

export const getFactorByIdEffect = createEffect(
  (actions$ = inject(Actions), factorService = inject(FactorService)) => {
    return actions$.pipe(
      ofType(factorActions.getFactorById),
      switchMap(({ factorId }) => {
        return factorService.getFactorById(factorId).pipe(
          map((response: Factor) => {
            return factorActions.getFactorByIdSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }

            return of(
              factorActions.getFactorByIdFailure({
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

export const deleteFactorEffect = createEffect(
  (actions$ = inject(Actions), factorService = inject(FactorService)) => {
    return actions$.pipe(
      ofType(factorActions.deleteFactor),
      switchMap(({ factorId }) => {
        return factorService.deleteFactor(factorId).pipe(
          map((response: Factor) => {
            return factorActions.deleteFactorSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }
            return of(
              factorActions.deleteFactorFailure({
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

export const createFactorEffect = createEffect(
  (actions$ = inject(Actions), factorService = inject(FactorService)) => {
    return actions$.pipe(
      ofType(factorActions.createFactor),
      switchMap(({ factor }) => {
        return factorService.createFactor(factor).pipe(
          map((response: Factor) => {
            return factorActions.createFactorSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }
            return of(
              factorActions.createFactorFailure({
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

export const updateFactorEffect = createEffect(
  (actions$ = inject(Actions), factorService = inject(FactorService)) => {
    return actions$.pipe(
      ofType(factorActions.updateFactor),
      switchMap(({ factor }) => {
        return factorService.updateFactor(factor).pipe(
          map((response: Factor) => {
            return factorActions.updateFactorSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }
            return of(
              factorActions.updateFactorFailure({
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
