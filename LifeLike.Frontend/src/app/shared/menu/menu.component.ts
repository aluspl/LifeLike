import { Component, OnInit } from '@angular/core';
import { RestService } from '../services/rest.service';
import  MenuItem  from '../models/MenuItem';
import { AuthenticationService } from '../services/authentication.service';
import UserLogin from '../models/UserLogin';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material';
import { RegisterDialogComponent } from '../dialogs/register/registerdialogcomponent';


@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent implements OnInit {
  MenuItems: MenuItem[];
  IsLogin: Boolean;
  CurrentUser: UserLogin;
  constructor(private restService: RestService,
    authService: AuthenticationService,
    public dialog: MatDialog) {
      this.IsLogin = authService.IsLogin;
      authService.currentUser.subscribe(x=>{
        this.CurrentUser=x
        this.IsLogin = x!=null;
      })
    }
  getMenuItems(): void {
    this.restService.getMenuItems()
      .subscribe(items => this.MenuItems = items);
  }
  ngOnInit() {
    this.getMenuItems();
  }

  register() {
    // dialogRef.afterClosed().subscribe(result => {
    //   console.log(`Dialog result: ${result}`); // Pizza!
    // });
  }
}
