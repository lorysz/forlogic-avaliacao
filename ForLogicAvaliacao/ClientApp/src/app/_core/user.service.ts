import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  setToken(token: string) {
    localStorage.setItem('token', token);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  clearToken() {
    localStorage.removeItem('token');
  }

  setNomeUsuario(nome: string) {
    localStorage.setItem('nomeUsuario', nome);
  }

  getNomeUsuario() {
    return localStorage.getItem('nomeUsuario');
  }

  clearNomeUsuario() {
    localStorage.removeItem('nomeUsuario');
  }

}
