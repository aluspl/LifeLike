import { Component, OnInit } from '@angular/core';
import { RestService } from '../../Services/rest.service';
import Log from '../../Models/Log';
import { share } from 'rxjs/operators';
import { Observable } from 'rxjs/Observable';
import {switchMap} from "rxjs/operator/switchMap";

@Component({
  selector: 'app-log',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.scss']
})
export class LogComponent implements OnInit {

  Logs: Observable<Log[]>;
  constructor(private restService: RestService) { }
  GetLogs(): void {
     this.Logs = this.restService.getLogList().pipe(
     share());
    console.log(this.Logs);

  }
  ngOnInit() {
    this.GetLogs();
  }

}
