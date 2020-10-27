import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Rate } from './rate';

@Injectable({
  providedIn: 'root'
})
export class RateService {

  constructor (
    private http: HttpClient
  ) { }

  getRates(params = {}) {
    // GET req na localhost:5001/api/cars?search=abc
    return this.http.get<Rate[]>(environment.apiUrl + '/rates', { params });
  }

  getRate(id: number) {
    return this.http.get<Rate>(environment.apiUrl + '/rates/' + id);
  }
}
