import { Component, OnInit } from '@angular/core';
import { ParkingTypeService } from '../parking-type.service';
import { ParkingType } from '../parking-type';

@Component({
  selector: 'app-parking-type-list',
  templateUrl: './parking-type-list.component.html',
  styleUrls: ['./parking-type-list.component.scss']
})
export class ParkingTypeListComponent implements OnInit {

  parkingTypes: ParkingType[] = [];

  searchText: string;

  constructor(
    private parkingTypeService: ParkingTypeService
  ) { }

  ngOnInit(): void {
    this.loadParkingTypes();
  }

  search(text): void {
    // this.loadProtests({ search: text });
  }

  loadParkingTypes(params = {}): void {
    this.parkingTypeService
      .getParkingTypes(params)
      .subscribe(c => {
        this.parkingTypes = c;
      });
      //callback
  }

}
