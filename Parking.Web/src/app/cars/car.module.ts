import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CarsRoutingModule } from './car-routing.module';
import { CarListComponent } from './car-list/car-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [CarListComponent],
  imports: [
    CommonModule,
    CarsRoutingModule,
    HttpClientModule,
    FormsModule
  ]
})
export class CarsModule { }