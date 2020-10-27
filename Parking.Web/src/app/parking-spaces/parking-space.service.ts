import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ParkingSpace } from './parking-space';

@Injectable({
  providedIn: 'root'
})
export class ParkingSpaceService {

  constructor (
    private http: HttpClient
  ) { }

  getParkingSpaces(params = {}) {
    // GET req na localhost:5001/api/cars?search=abc
    return this.http.get<ParkingSpace[]>(environment.apiUrl + '/parkingspaces', { params });
  }

  getParkingSpace(id: number) {
    return this.http.get<ParkingSpace>(environment.apiUrl + '/parkingspaces/' + id);
  }

  deleteParkingSpace(id: number) {
    return this.http.delete(environment.apiUrl + '/parkingspaces/' + id);
  }

  postParkingSpace(parkingSpace: ParkingSpace) {
    return this.http.post<ParkingSpace>(environment.apiUrl + '/parkingspaces', parkingSpace);
  }

  patchParkingSpace(id: number, parkingSpace: ParkingSpace) { 
    console.log('sending patch request to add an item');

    return this.http.patch(environment.apiUrl + '/parkingspaces/' + id, parkingSpace).subscribe(
      res => { 
        console.log('received ok response from patch request');
      },
      error => {
        console.error('There was an error during the request');
        console.log(error);
      });
  }

  updateAvailability(parkingSpace: ParkingSpace) { 
    return this.http.patch(environment.apiUrl + '/parkingspaces' + parkingSpace.id, parkingSpace)
  }
  
}