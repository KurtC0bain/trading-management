import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { Trade } from '../types/trade.interface';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TradeService {
  constructor(private http: HttpClient, private cookieService: CookieService) {}

  getAllTrades(): Observable<Trade[]> {
    // if (this.cookieService.get('.AspNetCore.Identity.Application') == null)
    //   return false;

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const tradeUrl = environment.apiUrl + '/trades';
    return this.http.get<Trade[]>(tradeUrl, httpOptions);
  }

  getTradeById(tradeId: string): Observable<Trade> {
    // if (this.cookieService.get('.AspNetCore.Identity.Application') == null)
    //   return false;

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const tradeUrl = environment.apiUrl + `/trades/${tradeId}`;
    return this.http.get<Trade>(tradeUrl, httpOptions);
  }
}
