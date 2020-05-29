import { Component, OnInit, Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserService } from './_core/user.service';

@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  logado: boolean;
  title = 'app';

  constructor(private service: UserService, private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.logado = this.service.getToken() ? true : false;
  }

  showSpinner() {
    this.spinner.show();
  }

  hideSpinner() {
    this.spinner.hide();
  }
}
