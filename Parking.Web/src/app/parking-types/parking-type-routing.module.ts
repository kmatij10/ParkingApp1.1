import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParkingTypeListComponent } from './parking-type-list/parking-type-list.component';

const routes: Routes = [
  { path: '', component: ParkingTypeListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ParkingTypesRoutingModule { }