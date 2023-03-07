import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiLoginRespose, ApiRegisterResponse } from '../../Entities/ApiResponse';
import { User } from '../../Entities/User';
import { ApiService } from './api.service';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(public api: ApiService, public http: HttpClient) { }
  public create(data: Array<string>): Observable<ApiRegisterResponse> {
    return this.http.post(this.api.base_url + "/authentication/register",data);
  }
  public login(data: Array<string>): Observable<ApiLoginRespose> {
    return this.http.post(this.api.base_url + "/authentication/login", data);
  }
  public user(): Observable<User> {
    return this.http.get(this.api.base_url+"/authentication/user", { headers: this.api.auth_headers });
  }
}

