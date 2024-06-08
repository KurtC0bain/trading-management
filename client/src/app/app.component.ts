import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTooltipModule } from '@angular/material/tooltip';
import { CommonModule } from '@angular/common';
import { PersistanceService } from './shared/services/persistance.service';
import { Store } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';
import { selectIsAuthorized } from './auth/store/reducers';
import { RouterModule } from '@angular/router';
import { authActions } from './auth/store/actions';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatTabsModule,
    MatTooltipModule,
    RouterOutlet,
    RouterModule,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  data$ = combineLatest({
    isAuthorized: this.store.select(selectIsAuthorized),
  });

  constructor(
    private router: Router,
    private store: Store,
    private cookiesService: CookieService
  ) {}

  ngOnInit(): void {
    let cookie = this.cookiesService.get('.AspNetCore.Identity.Application');
    let length = cookie.length > 0;
    if (length) {
      this.store.dispatch(authActions.checkAuthSuccess());
    } else {
      this.store.dispatch(authActions.checkAuthFailure());
    }
  }

  logout() {
    // Handle logout logic here, e.g., clear tokens, navigate to login page, etc.
    console.log('Logged out');

    this.store.dispatch(authActions.logout());
  }
}
