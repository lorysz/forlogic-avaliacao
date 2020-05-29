import { Component } from '@angular/core';
import { UserService } from '../_core/user.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private userService: UserService) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  sair() {
    this.userService.clearToken();
    this.userService.clearNomeUsuario();
    location.reload(true);
  }
}
