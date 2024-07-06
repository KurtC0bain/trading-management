import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { Factor } from '../types/factor.interface';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class FactorService {
  constructor(private http: HttpClient, private cookieService: CookieService) {}

  getAllFactors(): Observable<Factor[]> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const factorUrl = environment.apiUrl + '/factors';
    return this.http.get<Factor[]>(factorUrl, httpOptions);
  }

  getFactorById(factorId: string): Observable<Factor> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const factorUrl = environment.apiUrl + `/factors/${factorId}`;
    return this.http.get<Factor>(factorUrl, httpOptions);
  }

  deleteFactor(factorId: string): Observable<Factor> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const factorUrl = environment.apiUrl + `/factors/${factorId}`;
    return this.http.delete<Factor>(factorUrl, httpOptions);
  }

  createFactor(factor: Factor): Observable<Factor> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const factorUrl = environment.apiUrl + `/factors/`;
    return this.http.post<Factor>(factorUrl, factor, httpOptions);
  }

  updateFactor(factor: Factor): Observable<Factor> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };
    const factorUrl = environment.apiUrl + `/factors?factorId=${factor.id}`;
    return this.http.put<Factor>(factorUrl, factor, httpOptions);
  }
}
