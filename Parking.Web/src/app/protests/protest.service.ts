import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Protest } from './protest';
import { ProtestListRequest } from './protest-list/protest-list.request';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProtestService {

  constructor (
    private http: HttpClient
  ) { }

  getProtests(params = {}) {
    // GET req na localhost:5001/api/protests?search=abc
    return this.http.get<ProtestListRequest<Protest>>(environment.apiUrl + '/protests', { params });
  }

  getProtest(id) {
    return this.http.get<Protest>(environment.apiUrl + '/protests/' + id);
  }

  deleteProtest(id) {
    return this.http.delete(environment.apiUrl + '/protests/' + id)
  }
}
