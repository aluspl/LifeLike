import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { RegisterDialogComponent } from '../dialogs/register/registerdialogcomponent';
import MenuItem from '../models/MenuItem';
import UserLogin from '../models/UserLogin';
import { AuthenticationService } from '../services/authentication.service';
import { RestService } from '../services/rest.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent implements OnInit {
  MenuItems: MenuItem[];
  IsLogin: Boolean;
  CurrentUser: UserLogin;
  constructor(private readonly restService: RestService, authService: AuthenticationService, public dialog: MatDialog) {
    this.IsLogin = authService.IsLogin;
    authService.currentUser.subscribe((x) => {
      this.CurrentUser = x;
      this.IsLogin = x != undefined;
    });
  }
  getMenuItems(): void {
    this.restService.getMenuItems()
      .subscribe((items) => this.MenuItems = items);
  }
  ngOnInit() {
    this.getMenuItems();
  }

}
