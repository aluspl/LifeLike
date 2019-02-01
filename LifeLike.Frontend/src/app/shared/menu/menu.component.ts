import { Component, OnInit } from '@angular/core';
import { RestService } from '../services/rest.service';
import { MenuItem } from '../models/MenuItem';


@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent implements OnInit {
  MenuItems: MenuItem[];
  constructor(private restService: RestService) { }
  getMenuItems(): void {
    this.restService.getMenuItems()
      .subscribe(items => this.MenuItems = items);
  }
  ngOnInit() {
    this.getMenuItems();
  }

}
