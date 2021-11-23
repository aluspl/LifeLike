import { Component, OnInit } from '@angular/core';
import { AdminRestService } from '../../services/admin-rest.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss'],
})
export class AdminPageComponent implements OnInit {
    IsLoading: boolean;
    constructor(private readonly restService: AdminRestService) { }

    ngOnInit() {
    }

}
