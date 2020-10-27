import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ParkingSpacesRoutingModule } from './parking-space-routing.module';
import { ParkingSpaceListComponent } from './parking-space-list/parking-space-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ParkingSpaceDetailComponent } from './parking-space-detail/parking-space-detail.component';
import { ParkingSpaceFormComponent } from './parking-space-form/parking-space-form.component';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ParkingSpacePatchFormComponent } from './parking-space-patch-form/parking-space-patch-form.component';


@NgModule({
  declarations: [ParkingSpaceListComponent, ParkingSpaceDetailComponent, ParkingSpaceFormComponent, ParkingSpacePatchFormComponent],
  imports: [
    CommonModule,
    ParkingSpacesRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    ToastrModule.forRoot(),

  ],
  exports: [  ParkingSpacesRoutingModule  ]
})
export class ParkingSpacesModule { }