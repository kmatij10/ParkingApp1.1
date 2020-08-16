import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ParkingType } from './parking-type';

@Injectable({
  providedIn: 'root'
})
export class ParkingTypeService {

  constructor (
    private http: HttpClient
  ) { }

  getParkingTypes(params = {}) {
    // GET req na localhost:5001/api/cars?search=abc
    return this.http.get<ParkingType[]>(environment.apiUrl + '/parkingtypes', { params });
  }

  /*getCity(id) {
    return this.http.get<City>(environment.apiUrl + '/cities/' + id);
  }*/
}
