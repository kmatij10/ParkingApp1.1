import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { PaymentPanel } from './payment-panel';

@Injectable({
  providedIn: 'root'
})
export class PaymentPanelService {

  constructor (
    private http: HttpClient
  ) { }

  getPaymentPanels(params = {}) {
    // GET req na localhost:5001/api/cars?search=abc
    return this.http.get<PaymentPanel[]>(environment.apiUrl + '/paymentpanels', { params });
  }

  getPaymentPanel(id) {
    return this.http.get<PaymentPanel>(environment.apiUrl + '/paymentpanels/' + id);
  }
}