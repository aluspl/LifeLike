import { Component, OnInit } from '@angular/core';
import { RestService } from '../services/rest.service';
import  MenuItem  from '../models/MenuItem';
import { AuthenticationService } from '../services/authentication.service';
import UserLogin from '../models/UserLogin';
import { Router } from '@angular/router';
import { LoginComponent } from '../pages/login/login.component';
import { MatDialog } from '@angular/material';
import { RegisterComponent } from '../pages/register/register.component';
import { RegisterDialogComponent } from '../dialogs/register/registerdialogcomponent';
import { LoginDialogComponent } from '../dialogs/login/logindialog.component';


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
    private router: Router,
    private authService: AuthenticationService,
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
  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
  login() {
    let dialogRef = this.dialog.open(LoginDialogComponent, {
      height: '400px',
      width: '600px',
    });
    // dialogRef.afterClosed().subscribe(result => {
    //   console.log(`Dialog result: ${result}`); // Pizza!
    // });

  }
  register() {
    let dialogRef = this.dialog.open(RegisterDialogComponent, {
      height: '400px',
      width: '600px',
    });
    // dialogRef.afterClosed().subscribe(result => {
    //   console.log(`Dialog result: ${result}`); // Pizza!
    // });
  }
}
