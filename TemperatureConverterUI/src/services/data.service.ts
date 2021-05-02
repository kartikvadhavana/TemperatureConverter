import { Injectable } from '@angular/core';
import { HttpParams, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  get<T>(url: string, params?: HttpParams): Observable<any> {
    return this.http.get<T>(url, { params: params });
  }
}
