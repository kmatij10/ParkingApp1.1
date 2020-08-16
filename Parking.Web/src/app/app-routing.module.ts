import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: 'cars', loadChildren: () => import('./cars/car.module').then(m => m.CarsModule) },
  { path: 'rates', loadChildren: () => import('./rates/rate.module').then(m => m.RatesModule) },
  { path: 'parkingspaces', loadChildren: () => import('./parking-spaces/parking-space.module').then(m => m.ParkingSpacesModule) },
  { path: 'parkingtypes', loadChildren: () => import('./parking-types/parking-type.module').then(m => m.ParkingTypesModule) },
  { path: 'paymentpanels', loadChildren: () => import('./payment-panels/payment-panel.module').then(m => m.PaymentPanelsModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
