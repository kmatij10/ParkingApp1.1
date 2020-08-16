import { Injectable, ElementRef, ViewChild } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  @ViewChild("#loading") loading?: ElementRef;

  constructor (
  ) { }

  show() {
      let gif = document.getElementById('loading');
      gif?.classList.remove('hidden');
  }

  hide() {
    let gif = document.getElementById('loading');
    gif?.classList.add('hidden');
  }
}