import { Component, OnInit } from '@angular/core';
import { RestService } from '../services/rest.service';
import  MenuItem  from '../models/MenuItem';
import { AuthenticationService } from '../services/authentication.service';
import UserLogin from '../models/UserLogin';


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
    private authService: AuthenticationService) {
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
}
