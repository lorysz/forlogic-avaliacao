import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ClienteComponent } from './cliente/cliente.component';
import { AvaliacaoComponent } from './avaliacao/avaliacao.component';
import { AuthGuard } from './_helpers/auth.guard';
import { JwtInterceptor } from './_helpers/jwt.interceptor';
import { ErrorInterceptor } from './_helpers/error.interceptor';
import { NgxSpinnerModule } from 'ngx-spinner';
import { applicationHttpClientCreator, ApplicationHttpApi } from './http-api';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CadastrarClienteComponent } from './cliente/cadastrar-cliente/cadastrar-cliente.component';
import { ToastrModule } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { CadastroAvaliacaoComponent } from './avaliacao/cadastro-avaliacao/cadastro-avaliacao.component';
import { VisualizarAvaliacaoComponent } from './avaliacao/visualizar-avaliacao/visualizar-avaliacao.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    ClienteComponent,
    AvaliacaoComponent,
    CadastrarClienteComponent,
    CadastroAvaliacaoComponent,
    VisualizarAvaliacaoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent, pathMatch: 'full' },
      { path: 'cliente', component: ClienteComponent, canActivate: [AuthGuard] },
      { path: 'avaliacao', component: AvaliacaoComponent, canActivate: [AuthGuard] },
      { path: 'visualizar-avaliacao/:id', component: VisualizarAvaliacaoComponent, canActivate: [AuthGuard] },
      { path: 'nova-avaliacao', component: CadastroAvaliacaoComponent, canActivate: [AuthGuard] },
      { path: 'novo-cliente', component: CadastrarClienteComponent, canActivate: [AuthGuard] },
      { path: 'alterar-cliente/:id', component: CadastrarClienteComponent, canActivate: [AuthGuard] },
    ])
  ],
  providers: [
    {
      provide: ApplicationHttpApi,
      useFactory: applicationHttpClientCreator,
      deps: [HttpClient]
    },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
