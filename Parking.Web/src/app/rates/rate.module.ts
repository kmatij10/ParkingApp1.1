import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RatesRoutingModule } from './rate-routing.module';
import { RateListComponent } from './rate-list/rate-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [RateListComponent],
  imports: [
    CommonModule,
    RatesRoutingModule,
    HttpClientModule,
    FormsModule
  ]
})
export class RatesModule { }