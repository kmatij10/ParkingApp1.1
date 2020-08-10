import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Protest } from '../protest';
import { ProtestService } from '../protest.service';

@Component({
  selector: 'app-protest-detail',
  templateUrl: './protest-detail.component.html',
  styleUrls: ['./protest-detail.component.scss']
})
export class ProtestDetailComponent implements OnInit {

  constructor(
    private activatedRoute: ActivatedRoute,
    private protestService: ProtestService
  ) { }

  id: number;
  protest: Protest;

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
        this.id = +params.get('id');
        this.loadProtest(this.id);
    });
  }

  loadProtest(id): void {
    this.protestService
      .getProtest(id)
      .subscribe(p => this.protest = p);
  }

  onDelete(id) {
    this.protestService.deleteProtest(id).subscribe(_ => null);
  }

  onEnter(id) {
    alert("Brisem s idem " + id);
  }
}
