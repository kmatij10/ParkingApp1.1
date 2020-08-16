import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PaymentPanelDetailComponent } from './payment-panel-detail/payment-panel-detail.component';

const routes: Routes = [
  { path: ':id', component: PaymentPanelDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PaymentPanelsRoutingModule { }