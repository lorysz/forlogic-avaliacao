import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ApplicationHttpApi } from '../http-api';
import { UserService } from '../_core/user.service';
import { SpinnerService } from '../_core/spinner.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formLogin: FormGroup;
  userError = false;

  constructor(private fb: FormBuilder, private http: ApplicationHttpApi, private userService: UserService,
    private spinner: SpinnerService, private router: Router) { }

  ngOnInit() {
    const logado = this.userService.getToken() ? true : false;
    if (logado) {
      this.router.navigate(['/']);
    }

    this.validation();
  }

  validation() {
    this.formLogin = this.fb.group({
      login: ['', [Validators.required]],
      senha: ['', [Validators.required]]
    });
  }

  entrar() {
    if (this.formLogin.valid) {
      this.spinner.showSpinner();
      this.http.post('usuario/login', this.formLogin.value).subscribe((data: any) => {
        if (data && data.accessToken) {
          this.userService.setToken(data.accessToken);
          this.userService.setNomeUsuario(data.nomeCompleto);

          window.location.reload();
        } else {
          this.userError = true;
        }
        this.spinner.hideSpinner();
      }, () => {
        this.spinner.hideSpinner();
      });
    }
  }

}
