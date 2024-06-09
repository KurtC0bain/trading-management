import { Route } from '@angular/router';
import { AppComponent } from './app.component';

export const appRoutes: Route[] = [
  {
    path: '',
    loadChildren: () => import('./home/home.routes').then((m) => m.homeRoutes),
  },
  {
    path: 'register',
    loadChildren: () =>
      import('./auth/auth.routes').then((m) => m.registerRoutes),
  },
  {
    path: 'login',
    loadChildren: () => import('./auth/auth.routes').then((m) => m.loginRoutes),
  },
  {
    path: 'trades',
    loadChildren: () =>
      import('./trades/trades.routes').then((m) => m.tradesRoutes),
  },
  {
    path: 'setups',
    loadChildren: () =>
      import('./setups/setups.routes').then((m) => m.setupsRoutes),
  },
  {
    path: 'analysis',
    loadChildren: () =>
      import('./analysis/analysis.routes').then((m) => m.analysisRoutes),
  },
];
