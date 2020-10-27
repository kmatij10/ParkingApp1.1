import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParkingSpaceListComponent } from './parking-space-list/parking-space-list.component';
import { ParkingSpaceDetailComponent } from './parking-space-detail/parking-space-detail.component';
import { ParkingSpaceFormComponent } from './parking-space-form/parking-space-form.component';

const routes: Routes = [
  { path: '', component: ParkingSpaceListComponent },
  { path: 'new', component: ParkingSpaceFormComponent, },
  { path: 'patch', component: ParkingSpaceFormComponent, },
  { path: ':id', component: ParkingSpaceDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ParkingSpacesRoutingModule { }