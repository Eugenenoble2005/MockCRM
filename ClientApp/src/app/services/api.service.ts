import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  public base_url: string;
  auth_headers: { auth_token: string; };
  constructor(public _cookie: CookieService) {
    this.base_url = "https://localhost:7278/api"

    let token = this._cookie.get("token");
    this.auth_headers = { "auth_token": `${token}` };
  }
  
}
