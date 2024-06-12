import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { Trade } from '../types/trade.interface';
import { environment } from '../../../environments/environment';
import { AssetRateResponse } from '../types/asset-rate.interface';
import { CreateTradeRequest } from '../types/create-trade.interface';
import { UpdateTradeRequest } from '../types/update-trade.interface';
import { PairResponse } from '../types/pair.interface';

@Injectable({
  providedIn: 'root',
})
export class TradeService {
  constructor(private http: HttpClient, private cookieService: CookieService) {}

  getAllTrades(): Observable<Trade[]> {
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

  deleteTrade(tradeId: string): Observable<Trade> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const tradeUrl = environment.apiUrl + `/trades/${tradeId}`;
    return this.http.delete<Trade>(tradeUrl, httpOptions);
  }

  createTrade(trade: CreateTradeRequest): Observable<Trade> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const tradeUrl = environment.apiUrl + `/trades`;
    return this.http.post<Trade>(tradeUrl, trade, httpOptions);
  }

  updateTrade(trade: UpdateTradeRequest): Observable<Trade> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    trade.date.setDate(trade.date.getDate() + 1);
    const tradeUrl = environment.apiUrl + `/trades`;
    return this.http.put<Trade>(tradeUrl, trade, httpOptions);
  }

  getAssetsRates(tickerNames: string[]): Observable<AssetRateResponse[]> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const assetsRatesUrl = environment.apiUrl + '/rate/';
    return this.http.post<AssetRateResponse[]>(
      assetsRatesUrl,
      { TickerNames: tickerNames },
      httpOptions
    );
  }

  getAllPairs(): Observable<PairResponse[]> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const pairsUrl = environment.apiUrl + '/pairs/';
    return this.http.get<PairResponse[]>(pairsUrl, httpOptions);
  }
}
