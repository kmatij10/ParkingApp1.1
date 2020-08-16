import { Component, OnInit } from '@angular/core';
import { ParkingSpace } from '../parking-space';
import { ParkingSpaceService } from '../parking-space.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-parking-space-detail',
    templateUrl: './parking-space-detail.component.html',
    styleUrls: ['./parking-space-detail.component.scss']
})
export class ParkingSpaceDetailComponent implements OnInit {

  parkingSpace?: ParkingSpace;
  url: string;
  type: string;
  /* meaning of !: https://www.typescriptlang.org/docs/handbook/release-notes/typescript-2-7.html#definite-assignment-assertions */
  id!: number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private parkingSpaceService: ParkingSpaceService
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
        this.url = `https://www.google.com/maps/search/?api=1&query=${this.parkingSpace.lat},${this.parkingSpace.lng}`;
      });
  }

}