import { Component, OnInit } from '@angular/core';
import { ParkingSpace } from '../parking-space';
import { ParkingSpaceService } from '../parking-space.service';
import { ActivatedRoute } from '@angular/router';
import * as jsonpatch from 'fast-json-patch';
import { applyOperation } from 'fast-json-patch';
import { Rate } from 'src/app/rates/rate';
import { RateService } from 'src/app/rates/rate.service';
import { ParkingType } from 'src/app/parking-types/parking-type';
import { ParkingTypeService } from 'src/app/parking-types/parking-type.service';

@Component({
    selector: 'app-parking-space-detail',
    templateUrl: './parking-space-detail.component.html',
    styleUrls: ['./parking-space-detail.component.scss']
})
export class ParkingSpaceDetailComponent implements OnInit {

  parkingSpace?: ParkingSpace;
  parkingType: ParkingType;
  rate: Rate;
  url: string;
  type: string;
  price: number;
  /* meaning of !: https://www.typescriptlang.org/docs/handbook/release-notes/typescript-2-7.html#definite-assignment-assertions */
  id!: number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private parkingSpaceService: ParkingSpaceService,
    private rateService: RateService,
    private parkingTypeService: ParkingTypeService
  ) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
        this.id = Number(params.get('id'));
        this.loadParkingSpace();
    });
  }

  loadParkingSpace() {
    this.type = "handicapped";
    this.parkingSpaceService
      .getParkingSpace(this.id)
      .subscribe(result => {
        this.parkingSpace = result;
        //this.loadRate(this.parkingSpace.rateId);
        //this.loadType(this.parkingSpace.parkingTypeId);
        //this.getPrice(this.parkingSpace.rateId);
        //this.getType(this.parkingSpace.parkingTypeId);
        this.url = `https://www.google.com/maps/search/?api=1&query=${this.parkingSpace.lat},${this.parkingSpace.lng}`;
      });
  }

  loadRate(id: number) {
    this.rateService
      .getRate(id)
      .subscribe(result => this.rate = result)
  }

  getPrice(id) {
    this.rateService
      .getRate(id)
      .subscribe(result => this.price = result.priceHourly)
  }

  getType(id) {
    this.parkingTypeService
    .getParkingType(id)
    .subscribe(result => this.type = result.type)
  }

  loadType(id: number) {
    this.parkingTypeService
      .getParkingType(id)
      .subscribe(result => this.parkingType = result)
  }

}