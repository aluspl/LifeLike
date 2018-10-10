import { Component, OnInit } from '@angular/core';
import {map} from 'rxjs/internal/operators';
import {Config} from '../../Models/Config';
import {RestService} from '../../Services/rest.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public IsLoading: boolean;
  public Configs: Config[];
  constructor(private restService: RestService) { }
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
