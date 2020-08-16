import { Component, OnInit } from '@angular/core';
import { RateService } from '../rate.service';
import { Rate } from '../rate';

@Component({
  selector: 'app-rate-list',
  templateUrl: './rate-list.component.html',
  styleUrls: ['./rate-list.component.scss']
})
export class RateListComponent implements OnInit {

  rates: Rate[] = [];

  searchText: string;

  constructor(
    private rateService: RateService
  ) { }

  ngOnInit(): void {
    this.loadRates();
  }

  search(text): void {
    // this.loadProtests({ search: text });
  }

  loadRates(params = {}): void {
    this.rateService
      .getRates(params)
      .subscribe(c => {
        this.rates = c;
      });
      //callback
  }

}
