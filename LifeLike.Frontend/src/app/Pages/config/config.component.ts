import { Component, OnInit } from '@angular/core';
import { RestService } from '../../Services/rest.service';
import {map} from "rxjs/internal/operators";
import {Config} from "../../Models/Config";

@Component({
  selector: 'app-config',
  templateUrl: './config.component.html',
  styleUrls: ['./config.component.scss']
})

export class ConfigComponent implements OnInit {
  displayedColumns = ['Name', 'Value', 'DisplayName', 'Type'];
  IsLoading: boolean;
  Configs: Config[];
  constructor(private restService: RestService) { }
  GetLogs(): void {
    this.IsLoading=true;
     this.restService
       .getConfigs()
       .pipe(
         map(data=> {
           this.IsLoading=false;
           console.log(data);

           return data;
         })).subscribe(p=>this.Configs=p);

  }
  ngOnInit() {
    this.GetLogs();
  }

}
