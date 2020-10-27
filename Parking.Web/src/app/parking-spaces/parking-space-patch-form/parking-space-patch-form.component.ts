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
import { HttpClient } from '@angular/common/http';

import { compare } from 'fast-json-patch';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-parking-space-patch-form',
  templateUrl: './parking-space-patch-form.component.html',
  styleUrls: ['./parking-space-patch-form.component.scss']
})
export class ParkingSpacePatchFormComponent implements OnInit {

  patchParkingSpace: ParkingSpace;
  parkingSpace: ParkingSpace = {} as ParkingSpace;
  rates?: Rate[];
  parkingTypes?: ParkingType[];
  baseUrl: string;

  constructor(
    private parkingSpaceService: ParkingSpaceService,
    private rateService: RateService,
    private parkingTypeService: ParkingTypeService,
    private loadingService: LoadingService,
    private router: Router,
    private toastr: ToastrService,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.loadRates();
    this.loadParkingTypes();
  }

  onSubmit() {
    this.loadingService.show();
    const patch = compare(this.previousFormModel(), this.prepareFormModel());
    this.http.patch<any>(environment.apiUrl + '/parkingspaces/1', patch).subscribe(result => {
      console.log(result);
    }, error => console.error(error));;

    this.http.patch<any>(environment.apiUrl + '/parkingspaces/1', this.prepareFormModel()).subscribe(result =>     {
      console.log(result);
    }, error => console.error(error));;
    /*this.parkingSpaceService
      .postParkingSpace(this.parkingSpace)
      .subscribe(result => {
        this.loadingService.hide();
        this.toastr.success('Success');
        let parkingSpaceId = result.id;
        this.router.navigate(['parkingspaces/' + parkingSpaceId]);
      });*/
      
  }

  previousFormModel() {
    //const formModel = this.testForm.value;
    const retVal: any = {
      rateId: 1.2 as number
    };
    return retVal;
  }

  prepareFormModel() {    //const formModel = this.testForm.value;

    const retVal: any = {
      rateId: 3.4 as number
    };
    return retVal;
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