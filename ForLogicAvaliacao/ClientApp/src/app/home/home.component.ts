import { Component, OnInit } from '@angular/core';
import { ApplicationHttpApi } from '../http-api';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  dadosHome: any;

  constructor(private http: ApplicationHttpApi, private toastr: ToastrService) { }

  ngOnInit() {
    this.carregarDadosHome();
  }

  carregarDadosHome() {
    this.http.get('home').subscribe((data: any) => {
      this.dadosHome = data;
    }, () => {
      this.toastr.error('Problemas para validar o Cnpj do cliente.', 'Erro');
    });
  }

}
