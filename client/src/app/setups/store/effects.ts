import { inject } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { SetupService } from '../services/setup.service';
import { catchError, map, of, switchMap } from 'rxjs';
import { setupActions } from './actions';
import { Setup } from '../types/setup.interface';
import { ErrorResponse } from '../../shared/types/errorResponse.interface';
import { authActions } from '../../auth/store/actions';

export const getSetupsEffect = createEffect(
  (actions$ = inject(Actions), setupService = inject(SetupService)) => {
    return actions$.pipe(
      ofType(
        setupActions.getAllSetups,
        setupActions.deleteSetupSuccess,
        setupActions.createSetupSuccess,
        setupActions.updateSetupSuccess
      ),
      switchMap(() => {
        return setupService.getAllSetups().pipe(
          map((response: Setup[]) => {
            return setupActions.getAllSetupsSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }

            return of(
              setupActions.getAllSetupsFailure({
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

export const getSetupByIdEffect = createEffect(
  (actions$ = inject(Actions), setupService = inject(SetupService)) => {
    return actions$.pipe(
      ofType(setupActions.getSetupById),
      switchMap(({ setupId }) => {
        return setupService.getSetupById(setupId).pipe(
          map((response: Setup) => {
            return setupActions.getSetupByIdSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }

            return of(
              setupActions.getSetupByIdFailure({
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

export const deleteSetupEffect = createEffect(
  (actions$ = inject(Actions), setupService = inject(SetupService)) => {
    return actions$.pipe(
      ofType(setupActions.deleteSetup),
      switchMap(({ setupId }) => {
        return setupService.deleteSetup(setupId).pipe(
          map((response: Setup) => {
            return setupActions.deleteSetupSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }
            return of(
              setupActions.deleteSetupFailure({
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

export const createSetupEffect = createEffect(
  (actions$ = inject(Actions), setupService = inject(SetupService)) => {
    return actions$.pipe(
      ofType(setupActions.createSetup),
      switchMap(({ setup }) => {
        return setupService.createSetup(setup).pipe(
          map((response: Setup) => {
            return setupActions.createSetupSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }
            return of(
              setupActions.createSetupFailure({
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

export const updateSetupEffect = createEffect(
  (actions$ = inject(Actions), setupService = inject(SetupService)) => {
    return actions$.pipe(
      ofType(setupActions.updateSetup),
      switchMap(({ setup }) => {
        return setupService.updateSetup(setup).pipe(
          map((response: Setup) => {
            return setupActions.updateSetupSuccess({ response });
          }),
          catchError((errorResponse: ErrorResponse) => {
            if (errorResponse.status == 401) {
              return of(authActions.checkAuthFailure());
            }
            return of(
              setupActions.updateSetupFailure({
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
