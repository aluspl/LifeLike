import { Component } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { LoginDialogComponent } from './shared/dialogs/login/logindialog.component';
import UserLogin from './shared/models/UserLogin';
import { AuthenticationService } from './shared/services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'app';
  IsLogin: boolean;
  CurrentUser: UserLogin;
  Username = 'no login';
  constructor(private readonly router: Router,
              public dialog: MatDialog,
              private readonly authService: AuthenticationService) {
    this.IsLogin = authService.IsLogin;
    authService.currentUser.subscribe((x) => {
      this.CurrentUser = x;
      this.IsLogin = x !== undefined;
    });
  }
  logout() {
    this.authService.logout();
    this.router.navigate(['/']);
  }
  login() {
    const dialogRef = this.dialog.open(LoginDialogComponent, {
      height: '400px',
      width: '600px',
    });
  }
}
