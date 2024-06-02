import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterRequestInterface } from '../types/registerRequest.interface';
import { Observable } from 'rxjs';
import { AuthResponseInterface } from '../types/authResponse.interface';
import { environment } from '../../../environments/environment.development';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient, private cookieService: CookieService) {}

  register(data: RegisterRequestInterface): Observable<void> {
    const registerUrl = environment.apiUrl + '/register';
    return this.http.post<void>(registerUrl, data);
  }

  login(data: RegisterRequestInterface): Observable<AuthResponseInterface> {
    const loginUrl = environment.apiUrl + '/login';
    return this.http.post<AuthResponseInterface>(loginUrl, data);
  }

  logout(): Observable<void> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const logoutUrl = environment.apiUrl + '/logout';
    return this.http.post<void>(logoutUrl, null, httpOptions);
  }
}
