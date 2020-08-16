import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ParkingTypesRoutingModule } from './parking-type-routing.module';
import { ParkingTypeListComponent } from './parking-type-list/parking-type-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [ParkingTypeListComponent],
  imports: [
    CommonModule,
    ParkingTypesRoutingModule,
    HttpClientModule,
    FormsModule
  ]
})
export class ParkingTypesModule { }