import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/internal/operators';
import { AdminRestService } from '../../services/admin-rest.service';
import Config from '../../../../shared/models/Config';

@Component({
  selector: 'app-config',
  templateUrl: './config.component.html',
  styleUrls: ['./config.component.scss']
})

export class ConfigComponent implements OnInit {
  displayedColumns = ['Name', 'Value', 'DisplayName', 'Type','Actions'];
  IsLoading: boolean;
  Configs: Config[];
  error: string;

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
        },
          error => {
            console.log(error);
            error= error;
            this.IsLoading = false;
          })).subscribe(p => this.Configs = p);

  }
  Create() {

  }
  ngOnInit() {
    this.GetLogs();
  }

}
