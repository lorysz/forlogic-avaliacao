import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApplicationHttpApi } from '../../../app/http-api';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { SpinnerService } from '../../../app/_core/spinner.service';

@Component({
  selector: 'app-cadastrar-cliente',
  templateUrl: './cadastrar-cliente.component.html',
  styleUrls: ['./cadastrar-cliente.component.css']
})
export class CadastrarClienteComponent implements OnInit {

  formCliente: FormGroup;
  cnpjExistente = false;

  constructor(private fb: FormBuilder, private http: ApplicationHttpApi, private toastr: ToastrService,
    private route: ActivatedRoute, private spinner: SpinnerService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.validation(params['id'] ? parseInt(params['id']) : 0);
    });

    this.formCliente.get('cnpj').valueChanges.subscribe(cnpj => {
      this.cnpjExistente = false;
      if (cnpj.length === 18) {

        const idCliente = this.formCliente.get('idCliente').value;

        this.spinner.showSpinner();

        this.http.get(`cliente/validarcnpjexistente/?cnpj=${cnpj}&idCliente=${idCliente}`).subscribe((result: any) => {

          this.spinner.hideSpinner();

          if (result) {
            this.cnpjExistente = true;
            this.toastr.info('Este Cnpj já foi cadastrado anteriormente. Verifique a lista de clientes.', 'Atenção!')
          }
        }, error => {
          this.toastr.error('Problemas para validar o Cnpj do cliente.', 'Erro');
          this.spinner.hideSpinner();
        });
      }
    });
  }

  validation(idCliente = 0) {
    this.formCliente = this.fb.group({
      idCliente: [idCliente],
      razaoSocial: ['', [Validators.required]],
      nomeResponsavel: ['', [Validators.required]],
      cnpj: ['', [Validators.minLength(18)]],
    });

    if (idCliente > 0) {
      this.carregarCliente();
    }
  }

  salvar() {
    if (this.formCliente.valid) {
      if (this.formCliente.get('idCliente').value === 0) {
        this.http.post('cliente', this.formCliente.value).subscribe((result: any) => {

          if (result) {
            this.cnpjExistente = true;
            this.toastr.info('Este Cnpj já foi cadastrado anteriormente. Verifique a lista de clientes.', 'Atenção!')
          } else {
            this.toastr.success('Cliente salvo com sucesso.', 'Sucesso!');

            this.formCliente.reset();
          }

        }, error => this.toastr.error('Problemas para salvar o cliente.', 'Erro'));
      } else {
        this.http.put('cliente', this.formCliente.value).subscribe((result: any) => {
          this.toastr.success('Cliente alterado com sucesso.', 'Sucesso!');

          this.formCliente.reset();

        }, error => this.toastr.error('Problemas para alterar o cliente.', 'Erro'));
      }
    }
  }

  carregarCliente() {
    this.http.get('cliente/' + this.formCliente.get('idCliente').value).subscribe((result: any) => {
      this.formCliente.patchValue({
        idCliente: result.idCliente,
        razaoSocial: result.razaoSocial,
        nomeResponsavel: result.nomeResponsavel,
        cnpj: result.cnpj
      });
    }, error => this.toastr.error('Problemas para carregar o cliente.', 'Erro'));
  }

}
