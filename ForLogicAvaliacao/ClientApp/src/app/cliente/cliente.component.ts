import { Component, OnInit, Inject } from '@angular/core';
import { ApplicationHttpApi } from '../http-api';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {

  constructor(private http: ApplicationHttpApi, private router: Router, private fb: FormBuilder) { }
  todosClientes = [];
  clientesFiltrados =[];
  frmFiltro: FormGroup;

  ngOnInit() {
    this.validation();
    this.carregarClientes();

    this.frmFiltro.get('razaoSocial').valueChanges.subscribe(x => {
      this.aplicarFiltro(x);
    });
  }

  validation() {
    this.frmFiltro = this.fb.group({
      razaoSocial: ['']
    });
  }

  aplicarFiltro(razaoSocial: string) {
    if (razaoSocial) {
      this.clientesFiltrados = this.todosClientes.filter(loc => loc.razaoSocial.toLowerCase().startsWith(razaoSocial.toLowerCase()));
    } else {
      this.clientesFiltrados = this.todosClientes;
    }
  }

  carregarClientes() {
    this.http.get('cliente').subscribe((result: any) => {
      this.todosClientes = result;
      this.clientesFiltrados = result;
    }, error => console.error(error));
  }

  novo() {
    this.router.navigate(['/novo-cliente']);
  }

  alterar(idCliente: number) {
    this.router.navigate(['/alterar-cliente/' + idCliente]);
  }
}
