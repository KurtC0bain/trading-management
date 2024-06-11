import { inject } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { AuthService } from '../services/auth.service';
import { authActions } from './actions';
import { switchMap, map, catchError, of, tap, mergeMap } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { PersistanceService } from '../../shared/services/persistance.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

export const registerEffect = createEffect(
  (
    actions$ = inject(Actions),
    authService = inject(AuthService),
    router = inject(Router)
  ) => {
    return actions$.pipe(
      ofType(authActions.register),
      switchMap(({ request }) => {
        return authService.register(request).pipe(
          map(() => {
            return authActions.registerSuccess();
          }),
          tap(() => router.navigate(['/login'])),
          catchError((errorResponse: HttpErrorResponse) => {
            return of(
              authActions.registerFailure({
                errors: errorResponse.error.errors,
              })
            );
          })
        );
      })
    );
  },
  { functional: true }
);

export const loginEffect = createEffect(
  (
    actions$ = inject(Actions),
    authService = inject(AuthService),
    persistanceService = inject(PersistanceService),
    router = inject(Router)
  ) => {
    return actions$.pipe(
      ofType(authActions.login),
      switchMap(({ request }) => {
        return authService.login(request).pipe(
          map((response) => {
            persistanceService.set(
              '.AspNetCore.Identity.Application',
              response.accessToken
            );
            persistanceService.set('refresh_token', response.refreshToken);
            return authActions.loginSuccess({ response });
          }),
          tap(() => router.navigate([''])),
          catchError((response) => {
            console.log(response);
            if (response.status == 401) {
              return of(
                authActions.loginFailure({
                  errors: {
                    loginError: ['Email or password is incorrect'],
                  },
                })
              );
            }
            return of(
              authActions.loginFailure({
                errors: {
                  loginError: ['Server error'],
                },
              })
            );
          })
        );
      })
    );
  },
  { functional: true }
);

export const logoutEffect = createEffect(
  (
    actions$ = inject(Actions),
    authService = inject(AuthService),
    persistanceService = inject(PersistanceService),
    router = inject(Router)
  ) => {
    return actions$.pipe(
      ofType(authActions.logout),
      switchMap(() => {
        return authService.logout().pipe(
          map(() => {
            persistanceService.remove('.AspNetCore.Identity.Application');
            return authActions.logoutSuccess();
          }),
          tap(() => router.navigate(['/login'])),
          catchError(() => {
            return of(
              authActions.logoutFailure({
                errors: {
                  loginError: ['Logout failure'],
                },
              })
            );
          })
        );
      })
    );
  },
  { functional: true }
);

export const redirectAfterRegisterEffect = createEffect(
  (actions$ = inject(Actions), router = inject(Router)) => {
    return actions$.pipe(
      ofType(authActions.registerSuccess),
      tap(() => {
        router.navigateByUrl('/login');
      })
    );
  },
  { functional: true, dispatch: false }
);

export const checkAuthEffect = createEffect(
  (
    actions$ = inject(Actions),
    router = inject(Router),
    cookieService = inject(CookieService)
  ) => {
    return actions$.pipe(
      ofType(authActions.checkAuthFailure),
      map(() => {
        cookieService.delete('.AspNetCore.Identity.Application');
      }),
      tap(() => {
        router.navigateByUrl('/login');
      })
    );
  },
  { functional: true, dispatch: false }
);
