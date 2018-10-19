import { Component, OnInit } from '@angular/core';
import { RestService } from '../../Services/rest.service';
import Log from '../../Models/Log';
import {map} from "rxjs/internal/operators";

@Component({
  selector: 'app-log',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.scss']
})
export class LogComponent implements OnInit {
  displayedColumns = ['name', 'message'];
  IsLoading: boolean;
  Logs: Log[];
  constructor(private restService: RestService) { }
  GetLogs(): void {
    this.IsLoading=true;
     this.restService
       .getLogList()
       .pipe(
         map(data=> {
           this.IsLoading=false;
           console.log(data);

           return data;
         })).subscribe(p=>this.Logs=p);

  }
  ngOnInit() {
    this.GetLogs();
  }

}
