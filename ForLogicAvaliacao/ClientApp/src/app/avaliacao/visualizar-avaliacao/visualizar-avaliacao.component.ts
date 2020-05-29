import { Component, OnInit } from '@angular/core';
import { ApplicationHttpApi } from '../../../app/http-api';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-visualizar-avaliacao',
  templateUrl: './visualizar-avaliacao.component.html',
  styleUrls: ['./visualizar-avaliacao.component.css']
})
export class VisualizarAvaliacaoComponent implements OnInit {

  avaliacoes = [];

  constructor(private http: ApplicationHttpApi, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.carregarAvaliacoes(params.id);
    });
  }

  carregarAvaliacoes(idAvaliacao: number) {
    this.http.get('avaliacaocliente/' + idAvaliacao).subscribe((result: any) => {
      this.avaliacoes = result;
    }, error => console.error(error));
  }

}
