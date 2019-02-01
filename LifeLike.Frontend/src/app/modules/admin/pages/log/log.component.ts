import { Component, OnInit } from '@angular/core';
import {map} from 'rxjs/internal/operators';
import Log from 'src/app/shared/models/Log';
import { AdminRestService } from '../../services/admin-rest.service';

@Component({
  selector: 'app-log',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.scss']
})
export class LogComponent implements OnInit {
  displayedColumns = ['name', 'message'];
  IsLoading: boolean;
  Logs: Log[];
  constructor(private restService: AdminRestService) { }
  GetLogs(): void {
    this.IsLoading = true;
     this.restService
       .getLogList()
       .pipe(
         map(data => {
            this.IsLoading = false;
            console.log(data);
            return data;
         })).subscribe(p => this.Logs = p);

  }
  ngOnInit() {
    this.GetLogs();
  }

}
