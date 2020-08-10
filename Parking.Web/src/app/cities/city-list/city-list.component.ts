import { Component, OnInit } from '@angular/core';
import { CityService } from '../city.service';
import { City } from '../city';

@Component({
  selector: 'app-city-list',
  templateUrl: './city-list.component.html',
  styleUrls: ['./city-list.component.scss']
})
export class CityListComponent implements OnInit {

  cities: City[] = [];

  searchText: string;

  constructor(
    private cityService: CityService
  ) { }

  ngOnInit(): void {
    this.loadCities();
  }

  search(text): void {
    // this.loadProtests({ search: text });
  }

  loadCities(params = {}): void {
    this.cityService
      .getCities(params)
      .subscribe(c => {
        this.cities = c;
      });
      //callback
  }

}
