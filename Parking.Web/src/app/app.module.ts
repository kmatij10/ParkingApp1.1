import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProtestListComponent } from './protests/protest-list/protest-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ProtestDetailComponent } from './protests/protest-detail/protest-detail.component';
import { CityListComponent } from './cities/city-list/city-list.component';
import { CityDetailComponent } from './cities/city-detail/city-detail.component';
import { CarListComponent } from './cars/car-list/car-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ProtestListComponent,
    ProtestDetailComponent,
    CityListComponent,
    CityDetailComponent,
    CarListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
