import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { Subscription } from 'rxjs';
import { LoginDialogComponent } from '../dialogs/login/logindialog.component';
import UserLogin from '../models/UserLogin';
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
    this.dialog.open(LoginDialogComponent, dialogConfig);
  }
  ngOnInit() {

  }
  ngOnDestroy() {
    this.UserSub.unsubscribe();
  }
}
