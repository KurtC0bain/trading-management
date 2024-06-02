import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root',
})
export class PersistanceService {
  constructor(private cookieService: CookieService) {}

  set(key: string, data: string): void {
    try {
      this.cookieService.set(key, data);
    } catch (e) {
      console.error('Error saving to cookies', e);
    }
  }

  get(key: string): string {
    try {
      const cookie = this.cookieService.get(key);
      return cookie ? JSON.parse(cookie) : null;
    } catch (e) {
      console.error('Error retrieving from cookies', e);
      return '';
    }
  }

  remove(key: string): void {
    try {
      const cookie = this.cookieService.delete(key);
    } catch (e) {
      console.error('Error retrieving from cookies', e);
    }
  }
}
