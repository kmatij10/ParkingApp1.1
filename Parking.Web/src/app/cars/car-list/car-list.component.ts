import { Component, OnInit } from '@angular/core';
import { CarService } from '../car.service';
import { Car } from '../car';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.scss']
})
export class CarListComponent implements OnInit {

  cars: Car[] = [];

  searchText: string;

  constructor(
    private carService: CarService
  ) { }

  ngOnInit(): void {
    this.loadCars();
  }

  search(text): void {
    // this.loadProtests({ search: text });
  }

  loadCars(params = {}): void {
    this.carService
      .getCars(params)
      .subscribe(c => {
        this.cars = c;
      });
      //callback
  }

}
