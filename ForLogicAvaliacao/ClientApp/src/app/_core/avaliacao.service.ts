import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AvaliacaoService {

  constructor() { }

  getResultadoAvaliacaoGeral(qtdPromotor: number, qtdDetrator: number, qtdTotal: number) {
    return ((qtdPromotor - qtdDetrator) / qtdTotal) * 100;
  }

  getResultadoAvaliacaoIndividual(nota: number) {
    let tipoCliente = '';
    switch (nota) {
      case 10:
        tipoCliente = 'Promotor';
        break;
      case 9:
        tipoCliente = 'Promotor';
        break;
      case 8:
        tipoCliente = 'Neutro';
        break;
      case 7:
        tipoCliente = 'Neutro';
        break;

      default:
        tipoCliente = 'Detrator';
        break;
    }

    return tipoCliente;
  }
}
