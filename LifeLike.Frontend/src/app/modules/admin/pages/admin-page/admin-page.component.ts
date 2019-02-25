import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import  Page  from '../../../../shared/models/Page';
import { AdminRestService } from '../../services/admin-rest.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss']
})
export class AdminPage implements OnInit {
    Pages: Page[];
    IsLoading: boolean;
    constructor(private restService: AdminRestService) { }
    
    ngOnInit() {
    }

}
