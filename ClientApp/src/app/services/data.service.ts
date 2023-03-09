import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiRegisterResponse } from '../../Entities/ApiResponse';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(public http: HttpClient, public api: ApiService) { }
  public create(data: Array<any>): Observable<ApiRegisterResponse> {
    return this.http.post(this.api.base_url + "/data/store", data, { headers: this.api.auth_headers });
  }
  public get(): Observable<any> {
    return this.http.get(this.api.base_url + "/data/",{ headers: this.api.auth_headers });
  }
}
