import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ApplicationHttpApi } from '../http-api';
import { Router } from '@angular/router';

@Component({
  selector: 'app-avaliacao',
  templateUrl: './avaliacao.component.html',
  styleUrls: ['./avaliacao.component.css']
})
export class AvaliacaoComponent implements OnInit {

  todasAvaliacoes = [];
  avaliacoesFiltradas = [];
  frmFiltro: FormGroup;

  constructor(private http: ApplicationHttpApi, private router: Router, private fb: FormBuilder) { }

  ngOnInit() {
    this.validation();
    this.carregarAvaliacoes();

    this.frmFiltro.get('nota').valueChanges.subscribe(x => {
      this.aplicarFiltro(x);
    });

  }

  validation() {
    this.frmFiltro = this.fb.group({
      nota: ['']
    });
  }

  aplicarFiltro(nota: string) {
    if (nota) {
      this.avaliacoesFiltradas = this.todasAvaliacoes.filter(loc => loc.nota.toLowerCase().startsWith(nota.toLowerCase()));
    } else {
      this.avaliacoesFiltradas = this.todasAvaliacoes;
    }
  }

  carregarAvaliacoes() {
    this.http.get('avaliacao').subscribe((result: any) => {
      this.todasAvaliacoes = result;
      this.avaliacoesFiltradas = result;
    }, error => console.error(error));
  }

  novo() {
    this.router.navigate(['/nova-avaliacao']);
  }

  visualizar(idAvaliacao: number) {
    this.router.navigate(['/visualizar-avaliacao/' + idAvaliacao]);
  }

}
