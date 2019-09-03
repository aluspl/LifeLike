import { style } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import MenuItem from '../models/MenuItem';
import UserLogin from '../models/UserLogin';
import { AuthenticationService } from '../services/authentication.service';
import { RestService } from '../services/rest.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './template.html',
  styleUrls: ['./style.scss'],
})
export class ToolbarComponent implements OnInit {
  MenuItems: MenuItem[];
  IsLogin: boolean;
  CurrentUser: UserLogin;
  constructor(private readonly restService: RestService, authService: AuthenticationService, public dialog: MatDialog) {
    this.IsLogin = authService.IsLogin;
    authService.currentUser.subscribe((x) => {
      this.CurrentUser = x;
      this.IsLogin = x !== undefined;
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
