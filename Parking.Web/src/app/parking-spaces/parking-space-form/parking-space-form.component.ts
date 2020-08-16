import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { LoadingService } from '../../shared/loading/loading.service';
import { ToastrService } from 'ngx-toastr';
import { ParkingSpace } from '../parking-space';
import { Rate } from 'src/app/rates/rate';
import { ParkingType } from 'src/app/parking-types/parking-type';
import { ParkingSpaceService } from '../parking-space.service';
import { RateService } from 'src/app/rates/rate.service';
import { ParkingTypeService } from 'src/app/parking-types/parking-type.service';


@Component({
  selector: 'app-parking-space-form',
  templateUrl: './parking-space-form.component.html',
  styleUrls: ['./parking-space-form.component.scss']
})
export class ParkingSpaceFormComponent implements OnInit {

  parkingSpace: ParkingSpace = {} as ParkingSpace;
  rates?: Rate[];
  parkingTypes?: ParkingType[];

  constructor(
    private parkingSpaceService: ParkingSpaceService,
    private rateService: RateService,
    private parkingTypeService: ParkingTypeService,
    private loadingService: LoadingService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.loadRates();
    this.loadParkingTypes();
  }

  onSubmit() {
    this.loadingService.show();
    this.parkingSpaceService
      .postParkingSpace(this.parkingSpace)
      .subscribe(result => {
        this.loadingService.hide();
        this.toastr.success('Success');
        let parkingSpaceId = result.id;
        this.router.navigate(['parkingspaces/' + parkingSpaceId]);
      });
  }

  loadRates() {
    this.rateService
      .getRates()
      .subscribe(result => this.rates = result)
  }

  loadParkingTypes() {
    this.parkingTypeService
      .getParkingTypes()
      .subscribe((result: any) => this.parkingTypes = result)
  }

}