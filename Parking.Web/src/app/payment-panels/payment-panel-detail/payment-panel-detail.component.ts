import { Component, OnInit } from '@angular/core';
import { PaymentPanel } from '../payment-panel';
import { PaymentPanelService } from '../payment-space.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-payment-panel-detail',
    templateUrl: './payment-panel-detail.component.html',
    styleUrls: ['./payment-panel-detail.component.scss']
})
export class PaymentPanelDetailComponent implements OnInit {

  paymentPanel?: PaymentPanel;
  /* meaning of !: https://www.typescriptlang.org/docs/handbook/release-notes/typescript-2-7.html#definite-assignment-assertions */
  id!: number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private paymentPanelService: PaymentPanelService
  ) { }

  ngOnInit(): void {
    
  }


}