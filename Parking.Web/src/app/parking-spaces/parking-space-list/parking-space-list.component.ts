import { Component, OnInit } from '@angular/core';
import * as Leaflet from 'leaflet';
import { ParkingSpaceService } from '../parking-space.service';
import { ParkingSpace } from '../parking-space';
import { Rate } from 'src/app/rates/rate';
import { RateService } from 'src/app/rates/rate.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-parking-space-list',
  templateUrl: './parking-space-list.component.html',
  styleUrls: ['./parking-space-list.component.scss']
})
export class ParkingSpaceListComponent implements OnInit {
  parkingSpaces: ParkingSpace[] = [];
  rates: Rate[] = [];
  rate: Rate;
  searchText: string;
  price: number;

  constructor(
    private parkingSpaceService: ParkingSpaceService,
    private rateService: RateService,
    private router: Router
  ) { }

  map: Leaflet.Map;

  ngOnInit(): void {
    this.loadParkingSpaces();
    // this.loadRates();
  }

  search(text): void {
    // this.loadParkingSpaces({ search: text });
  }

  initMap() {
    this.map = Leaflet.map('map').setView([45.800440, 15.994100], 13);
    Leaflet.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: 'edupala.com © Angular LeafLet',
    }).addTo(this.map);

    var greenIcon = Leaflet.icon({
      iconUrl: 'https://leafletjs.com/examples/custom-icons/leaf-green.png',
      shadowUrl: 'https://leafletjs.com/examples/custom-icons/leaf-shadow.png',
  
      iconSize:     [38, 95], // size of the icon
      shadowSize:   [50, 64], // size of the shadow
      iconAnchor:   [22, 94], // point of the icon which will correspond to marker's location
      shadowAnchor: [4, 62],  // the same for the shadow
      popupAnchor:  [-3, -76] // point from which the popup should open relative to the iconAnchor
    });
    var redIcon = Leaflet.icon({
      iconUrl: 'https://leafletjs.com/examples/custom-icons/leaf-red.png',
      shadowUrl: 'https://leafletjs.com/examples/custom-icons/leaf-shadow.png',
  
      iconSize:     [38, 95], // size of the icon
      shadowSize:   [50, 64], // size of the shadow
      iconAnchor:   [22, 94], // point of the icon which will correspond to marker's location
      shadowAnchor: [4, 62],  // the same for the shadow
      popupAnchor:  [-3, -76] // point from which the popup should open relative to the iconAnchor
    });

    // Leaflet.marker([28.6, 77]).addTo(this.map).bindPopup('Delhi').openPopup();
     //Leaflet.marker([34, 77],{icon: greenIcon}).addTo(this.map).bindPopup('<b>Leh').openPopup();
    this.parkingSpaces.forEach(element => {
      if (element.availabilityId == 1) {
        //let rateId = element.rateId;
        //this.getPrice(rateId);
        Leaflet.marker([element.lat,element.lng],{icon: greenIcon}).bindPopup(this.getPopupText(element)).addTo(this.map); 
      } 
      else {
        Leaflet.marker([element.lat,element.lng],{icon: redIcon}).bindPopup(this.getPopupTextUnavailable(element)).addTo(this.map);
      }
    });
  }

  loadParkingSpaces(params = {}): void {
    this.parkingSpaceService
      .getParkingSpaces(params)
      .subscribe(c => {
        this.parkingSpaces = c;
        // this.loadRates();
        this.initMap();
      });
      //callback
  }

  getPopupText(parking: ParkingSpace): string {
    // let rateId = parking.rateId;
    // this.getPrice(rateId);
    console.log(this.rate);
    let result = `Parking space ${parking.id}<br />`;
    result += `Price Hourly: <b>${parking.rate.priceHourly}</b><br />`;
    result += `View <a href="${this.getPopupLink(parking)}">Details</a>`
    return result;
  }

  getPopupTextUnavailable(parking: ParkingSpace): string {
    // let rateId = parking.rateId;
    // this.getPrice(rateId);
    let result = `Parking space ${parking.id}<br />`;
    result += `Unavailable parking spot<br />`;
    result += `View <a href="${this.getPopupLink(parking)}">Details</a>`
    return result;
  }

  getPopupLink(parking: ParkingSpace): string {
    return `${window.location.href}/${parking.id}`;
  }

  loadRates() {
    this.rateService
      .getRates()
      .subscribe(result => this.rates = result)
  }

  getPrice(id){
    this.rateService
      .getRate(id)
      .subscribe(result => this.price = result.priceHourly)
  }
}