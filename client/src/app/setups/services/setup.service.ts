import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { Setup } from '../types/setup.interface';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SetupService {
  constructor(private http: HttpClient, private cookieService: CookieService) {}

  getAllSetups(): Observable<Setup[]> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const setupUrl = environment.apiUrl + '/setups';
    return this.http.get<Setup[]>(setupUrl, httpOptions);
  }

  getSetupById(setupId: string): Observable<Setup> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const setupUrl = environment.apiUrl + `/setups/${setupId}`;
    return this.http.get<Setup>(setupUrl, httpOptions);
  }

  deleteSetup(setupId: string): Observable<Setup> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const setupUrl = environment.apiUrl + `/setups/${setupId}`;
    return this.http.delete<Setup>(setupUrl, httpOptions);
  }

  createSetup(setup: Setup): Observable<Setup> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const setupUrl = environment.apiUrl + `/setups/`;
    return this.http.post<Setup>(setupUrl, setup, httpOptions);
  }

  updateSetup(setup: Setup): Observable<Setup> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };
    const setupUrl = environment.apiUrl + `/setups?setupId=${setup.id}`;
    return this.http.put<Setup>(setupUrl, setup, httpOptions);
  }
}
