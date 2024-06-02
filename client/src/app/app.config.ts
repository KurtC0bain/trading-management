import { ApplicationConfig, isDevMode } from '@angular/core';
import { provideRouter } from '@angular/router';
import { appRoutes } from './app.routes';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideState, provideStore } from '@ngrx/store';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { authFeatureKey, authReducer } from './auth/store/reducers';
import { provideHttpClient } from '@angular/common/http';
import { provideEffects } from '@ngrx/effects';
import * as authEffects from './auth/store/effects';

export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(),
    provideRouter(appRoutes),
    provideAnimationsAsync(),
    provideStore(),
    provideState(authFeatureKey, authReducer),
    provideEffects(authEffects),
    provideStoreDevtools({
      maxAge: 25,
      logOnly: !isDevMode(),
      autoPause: true,
      trace: false,
      traceLimit: 7,
    }),
  ],
};
