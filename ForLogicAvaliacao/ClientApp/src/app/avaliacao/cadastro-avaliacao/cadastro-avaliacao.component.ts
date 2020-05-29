import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ApplicationHttpApi } from '../../../app/http-api';
import { ToastrService } from 'ngx-toastr';
import { AvaliacaoService } from '../../../app/_core/avaliacao.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro-avaliacao',
  templateUrl: './cadastro-avaliacao.component.html',
  styleUrls: ['./cadastro-avaliacao.component.css']
})
export class CadastroAvaliacaoComponent implements OnInit {

  formAvaliacao: FormGroup;
  formRespostaAvaliacao: FormGroup;
  clientesAvaliados = [];
  dadosAvaliacao: any;
  clientes = [];
  pagina = 1;
  mediaGeral: number;

  constructor(private fb: FormBuilder, private http: ApplicationHttpApi,
    private toastr: ToastrService, private avaliacaoService: AvaliacaoService, private router: Router) { }

  ngOnInit() {
    this.validation();
    this.carregarComboCliente();
  }

  validation() {
    this.formAvaliacao = this.fb.group({
      mes: ['', [Validators.required]],
      ano: ['', [Validators.required]]
    });

    this.formRespostaAvaliacao = this.fb.group({
      cliente: [, [Validators.required]],
      nota: ['', [Validators.required]],
      motivo: ['', [Validators.required]]
    });
  }

  salvar() {
    if (this.clientesAvaliados.length > 0 && this.pagina === 2) {
      const avaliacaoCompleta = {
        mes: parseInt(this.formAvaliacao.get('mes').value),
        ano: parseInt(this.formAvaliacao.get('ano').value),
        nota: this.mediaGeral,
        respostas: this.clientesAvaliados
      };

      this.http.post('avaliacao', avaliacaoCompleta).subscribe((result: any) => {
        if (result) {
          this.toastr.info(result, 'Atenção!')
        } else {
          this.toastr.success('Avaliação salva com sucesso.', 'Sucesso!');
          this.router.navigate(['/avaliacao']);
        }

        this.formAvaliacao.reset();

      }, error => this.toastr.error('Problemas para salvar a avaliação.', 'Erro'));

    }
  }

  salvarDadosAvaliacao() {
    if (this.formAvaliacao.valid) {
      this.http.get('avaliacao/validacao/?mes=' + this.formAvaliacao.get('mes').value + '&ano=' + this.formAvaliacao.get('ano').value).subscribe((result: any) => {
        if (result) {
          this.pagina = 2;
        } else {
          this.toastr.info('Já foi realizado uma avaliação este mês.', 'Atenção!');
        }

      }, error => this.toastr.error('Problemas para carregar a combo de clientes.', 'Erro'));
    }
  }

  voltar() {
    this.pagina = 1;
  }

  adicionar() {
    if (this.formAvaliacao.valid && this.formRespostaAvaliacao.valid && this.pagina === 2) {
      this.clientesAvaliados.push({
        cliente: this.clientes.find(cli => cli.idCliente == this.formRespostaAvaliacao.get('cliente').value),
        idCliente: parseInt(this.formRespostaAvaliacao.get('cliente').value),
        nota: parseInt(this.formRespostaAvaliacao.get('nota').value),
        motivo: this.formRespostaAvaliacao.get('motivo').value,
        resultadoAvaliacao: this.avaliacaoService.getResultadoAvaliacaoIndividual(parseInt(this.formRespostaAvaliacao.get('nota').value))
      });
      const qtdPromotor = this.clientesAvaliados.filter(x => x.resultadoAvaliacao === 'Promotor').length;
      const qtdDetrator = this.clientesAvaliados.filter(x => x.resultadoAvaliacao === 'Detrator').length;
      const qtdTotal = this.clientesAvaliados.length;

      this.mediaGeral = this.avaliacaoService.getResultadoAvaliacaoGeral(qtdPromotor, qtdDetrator, qtdTotal);

      this.clientes = this.clientes.filter(cli => cli.idCliente != this.formRespostaAvaliacao.get('cliente').value);
      this.formRespostaAvaliacao.get('cliente').setValue('');
      this.formRespostaAvaliacao.reset();
    }
  }

  carregarComboCliente() {
    this.http.get('cliente/combo').subscribe((result: any) => {
      this.clientes = result;
    }, error => this.toastr.error('Problemas para carregar a combo de clientes.', 'Erro'));
  }

}
