import { Component, OnInit } from '@angular/core';
import { ProtestService } from '../protest.service';
import { Protest } from '../protest';

@Component({
  selector: 'app-protest-list',
  templateUrl: './protest-list.component.html',
  styleUrls: ['./protest-list.component.scss']
})
export class ProtestListComponent implements OnInit {

  protests: Protest[] = [];

  searchText: string;

  constructor(
    private protestService: ProtestService
  ) { }

  ngOnInit(): void {
    this.loadProtests();
  }

  search(text): void {
    this.loadProtests({ search: text });
  }

  loadProtests(params = {}): void {
    this.protestService
      .getProtests(params)
      .subscribe((p: any) => {
        this.protests = p.response;
      });
      //callback
  }

}
