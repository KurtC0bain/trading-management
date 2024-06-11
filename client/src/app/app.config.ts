import {
  ApplicationConfig,
  importProvidersFrom,
  isDevMode,
} from '@angular/core';
import { provideRouter } from '@angular/router';
import { appRoutes } from './app.routes';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideState, provideStore } from '@ngrx/store';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { authFeatureKey, authReducer } from './auth/store/reducers';
import { provideHttpClient } from '@angular/common/http';
import { provideEffects } from '@ngrx/effects';
import * as authEffects from './auth/store/effects';
import * as tradeEffects from './trades/store/effects';
import * as factorEffects from './factors/store/effects';
import * as setupEffects from './setups/store/effects';
import { tradeFeatureKey, tradeReducer } from './trades/store/reducers';
import { MatNativeDateModule } from '@angular/material/core';
import { factorFeatureKey, factorReducer } from './factors/store/reducers';
import { setupFeatureKey, setupReducer } from './setups/store/reducers';

export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(),
    provideRouter(appRoutes),
    provideAnimationsAsync(),
    provideStore(),
    importProvidersFrom(MatNativeDateModule),
    provideState(authFeatureKey, authReducer),
    provideState(tradeFeatureKey, tradeReducer),
    provideState(factorFeatureKey, factorReducer),
    provideState(setupFeatureKey, setupReducer),
    provideEffects(authEffects),
    provideEffects(tradeEffects),
    provideEffects(factorEffects),
    provideEffects(setupEffects),
    provideStoreDevtools({
      maxAge: 25,
      logOnly: !isDevMode(),
      autoPause: true,
      trace: false,
      traceLimit: 7,
    }),
  ],
};
