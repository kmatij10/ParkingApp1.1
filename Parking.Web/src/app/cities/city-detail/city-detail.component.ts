import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { City } from '../city';
import { CityService } from '../city.service';

@Component({
  selector: 'app-city-detail',
  templateUrl: './city-detail.component.html',
  styleUrls: ['./city-detail.component.scss']
})
export class CityDetailComponent implements OnInit {

  constructor(
    private activatedRoute: ActivatedRoute,
    private cityService: CityService
  ) { }

  id: number;
  city: City;

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
        this.id = +params.get('id');
        this.loadCity(this.id);
    });
  }

  loadCity(id): void {
    this.cityService
      .getCity(id)
      .subscribe(p => {
        this.city = p;
      });
  }
}
