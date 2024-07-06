import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { AssetsIncome, SetupsEfficiency } from '../types/analysis.interface';
import { AssetsIncomeResponse } from '../types/assetsIncome-response.interface';
import { SetupsEfficiencyResponse } from '../types/setupsEfficiency-response.interface';

@Injectable({
  providedIn: 'root',
})
export class AnalysisService {
  constructor(private http: HttpClient, private cookieService: CookieService) {}

  getAssetsIncome(): Observable<AssetsIncomeResponse> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const analysisUrl = environment.apiUrl + '/assets-income';
    return this.http.get<AssetsIncomeResponse>(analysisUrl, httpOptions);
  }

  getSetupEfficiency(): Observable<SetupsEfficiencyResponse> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization:
          'Bearer ' +
          this.cookieService.get('.AspNetCore.Identity.Application'),
      }),
    };

    const analysisUrl = environment.apiUrl + '/setup-efficiency';
    return this.http.get<SetupsEfficiencyResponse>(analysisUrl, httpOptions);
  }
}
