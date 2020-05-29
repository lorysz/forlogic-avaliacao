import { Injectable } from '@angular/core';
import { AppComponent } from '../app.component';

@Injectable({
  providedIn: 'root'
})

export class SpinnerService {

  constructor(private appComponent: AppComponent) { }

  showSpinner() {
    this.appComponent.showSpinner();
  }

  hideSpinner() {
    this.appComponent.hideSpinner();
  }
}
