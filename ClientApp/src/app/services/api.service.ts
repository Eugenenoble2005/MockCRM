import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  public base_url: string;
  auth_headers: { auth_token: string; };
  constructor(public _cookie: CookieService) {
    this.base_url = "http://139.59.154.185/server/api"

    let token = this._cookie.get("token");
    this.auth_headers = { "auth_token": `${token}` };
  }
  
}
