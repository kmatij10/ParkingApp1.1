import { Component, OnInit } from '@angular/core';
import * as Leaflet from 'leaflet';
import { ParkingSpaceService } from '../parking-space.service';
import { ParkingSpace } from '../parking-space';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-parking-space-list',
  templateUrl: './parking-space-list.component.html',
  styleUrls: ['./parking-space-list.component.scss']
})
export class ParkingSpaceListComponent implements OnInit {
  parkingSpaces: ParkingSpace[] = [];

  searchText: string;

  constructor(
    private parkingSpaceService: ParkingSpaceService,
    private router: Router
  ) { }

  map: Leaflet.Map;

  ngOnInit(): void {
    this.loadParkingSpaces();
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
    // Leaflet.marker([28.6, 77]).addTo(this.map).bindPopup('Delhi').openPopup();
     //Leaflet.marker([34, 77],{icon: greenIcon}).addTo(this.map).bindPopup('<b>Leh').openPopup();
    this.parkingSpaces.forEach(element => {
      Leaflet.marker([element.lat,element.lng],{icon: greenIcon}).bindPopup(this.getPopupText(element)).addTo(this.map);  
    });
  }

  loadParkingSpaces(params = {}): void {
    this.parkingSpaceService
      .getParkingSpaces(params)
      .subscribe(c => {
        this.parkingSpaces = c;
        this.initMap();
      });
      //callback
  }

  getPopupText(parking: ParkingSpace): string {
    parking.rate = { rate: 20 };
    let result = `Parkirno mjesto: ${parking.id}<br />`;
    result += `Cijena: <b>${parking.rate.rate}</b><br />`;
    result += `Rezerviraj <a href="${this.getPopupLink(parking)}">odmah</a>`
    return result;
  }

  getPopupLink(parking: ParkingSpace): string {
    return `${window.location.href}/${parking.id}`;
  }

  

}