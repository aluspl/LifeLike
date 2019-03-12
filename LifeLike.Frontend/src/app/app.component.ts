import { Component } from '@angular/core';
import { AuthenticationService } from './shared/services/authentication.service';
import { Router } from '@angular/router';
import UserLogin from './shared/models/UserLogin';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'app';
  IsLogin: Boolean;
  CurrentUser: UserLogin;
  Username = "no login";
  constructor(private router: Router,
    private authService: AuthenticationService) {
    this.IsLogin = authService.IsLogin;
    authService.currentUser.subscribe(x=>{
      this.CurrentUser=x
      this.IsLogin = x!=null;
    });
  }
  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
