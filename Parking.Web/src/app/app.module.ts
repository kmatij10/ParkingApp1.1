import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CarsModule } from './cars/car.module';
import { ParkingSpacesModule } from './parking-spaces/parking-space.module';
import { PaymentPanelsModule } from './payment-panels/payment-panel.module';
import { RatesModule } from './rates/rate.module';
import { ParkingTypesModule } from './parking-types/parking-type.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    //BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    CarsModule,
    ParkingSpacesModule,
    PaymentPanelsModule,
    RatesModule,
    ParkingTypesModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
