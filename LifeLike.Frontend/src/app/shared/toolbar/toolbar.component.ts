import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { Subscription } from 'rxjs';
import UserLogin from '../models/UserLogin';
import { LoginComponent } from '../pages/login/login.component';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './template.html',
  styleUrls: ['./style.scss'],
})
export class ToolbarComponent implements OnInit, OnDestroy {

  IsLogin: boolean;
  CurrentUser: UserLogin;
  UserSub: Subscription;
  constructor(private authService: AuthenticationService, private dialog: MatDialog) {
    this.UserSub = authService.currentUser.subscribe((x) => {
      this.CurrentUser = x;
      this.IsLogin = authService.IsLogin;
    });
  }
  logout(): void {
    this.authService.logout();
    this.IsLogin = false;
  }
  login(): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '90%';

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    this.dialog.open(LoginComponent, dialogConfig);
  }
  ngOnInit() {

  }
  ngOnDestroy() {
    this.UserSub.unsubscribe();
  }
}
