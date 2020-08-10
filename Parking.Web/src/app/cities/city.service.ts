import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { City } from './city';
import { ProtestListRequest } from './city-list/city-list.request';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor (
    private http: HttpClient
  ) { }

  getCities(params = {}) {
    return this.http.get<City[]>(environment.apiUrl + '/cities', { params });
  }

  getCity(id) {
    return this.http.get<City>(environment.apiUrl + '/cities/' + id);
  }
}
