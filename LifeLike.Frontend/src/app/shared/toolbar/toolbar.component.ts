import { Component, OnInit } from '@angular/core';
import { RestService } from '../services/rest.service';
import MenuItem from '../models/MenuItem';
import { AuthenticationService } from '../services/authentication.service';
import UserLogin from '../models/UserLogin';
import { MatDialog } from '@angular/material';
import { style } from '@angular/animations';


@Component({
  selector: 'app-toolbar',
  templateUrl: './template.html',
  styleUrls: ["./style.scss"]
})
export class ToolbarComponent implements OnInit {
  MenuItems: MenuItem[];
  IsLogin: Boolean;
  CurrentUser: UserLogin;
  constructor(private restService: RestService, authService: AuthenticationService, public dialog: MatDialog) {
    this.IsLogin = authService.IsLogin;
    authService.currentUser.subscribe(x => {
      this.CurrentUser = x
      this.IsLogin = x != null;
    })
  }
  getMenuItems(): void {
    this.restService.getMenuItems()
      .subscribe(items => this.MenuItems = items);
  }
  ngOnInit() {
    this.getMenuItems();
  }

}
