import { Component, OnInit } from '@angular/core';
import {map} from 'rxjs/internal/operators';
import Log from 'src/app/shared/models/Log';
import { AdminRestService } from '../../services/admin-rest.service';
import { Config } from 'src/app/shared/models/Config';

@Component({
  selector: 'app-config',
  templateUrl: './config.component.html',
  styleUrls: ['./config.component.scss']
})

export class ConfigComponent implements OnInit {
  displayedColumns = ['Name', 'Value', 'DisplayName', 'Type'];
  IsLoading: boolean;
  Configs: Config[];
  constructor(private restService: AdminRestService) { }
  GetLogs(): void {
    this.IsLoading = true;
     this.restService
       .getConfigs()
       .pipe(
         map(data => {
           this.IsLoading = false;
           console.log(data);
           return data;
         })).subscribe(p => this.Configs = p);

  }
  ngOnInit() {
    this.GetLogs();
  }

}
