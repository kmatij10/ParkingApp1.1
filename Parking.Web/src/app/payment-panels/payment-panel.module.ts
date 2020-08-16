import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PaymentPanelsRoutingModule } from './payment-panel-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { PaymentPanelDetailComponent } from './payment-panel-detail/payment-panel-detail.component';


@NgModule({
  declarations: [PaymentPanelDetailComponent],
  imports: [
    CommonModule,
    PaymentPanelsRoutingModule,
    HttpClientModule,
    FormsModule
  ]
})
export class PaymentPanelsModule { }