import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProtestListComponent } from './protests/protest-list/protest-list.component';
import { ProtestDetailComponent } from './protests/protest-detail/protest-detail.component';
import { CityListComponent } from './cities/city-list/city-list.component';
import { CityDetailComponent } from './cities/city-detail/city-detail.component';
import { CarListComponent } from './cars/car-list/car-list.component';


const routes: Routes = [
  { path: '', component: CarListComponent },
  { path: 'protests', component: ProtestListComponent },
  { path: 'protests/:id', component: ProtestDetailComponent },
  { path: 'cities', component: CityListComponent },
  { path: 'cities/:id', component: CityDetailComponent },
  { path: 'cars', component: CarListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
