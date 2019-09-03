import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { map } from 'rxjs/internal/operators';
import Config from '../../../../shared/models/Config';
import { ConfigCreateComponent } from '../../dialogs/config-create/config-create.component';
import { ConfigEditComponent } from '../../dialogs/config-edit/config-edit.component';
import { AdminRestService } from '../../services/admin-rest.service';

@Component({
  selector: 'app-config',
  templateUrl: './config.component.html',
  styleUrls: ['./config.component.scss'],
})

export class ConfigComponent implements OnInit {
  displayedColumns = ['Name', 'Value', 'DisplayName', 'Type', 'Actions'];
  IsLoading: boolean;
  Configs: Config[];
  error: string;

  constructor(private readonly restService: AdminRestService, private readonly dialog: MatDialog) { }
  GetConfigs(): void {
    this.IsLoading = true;
    this.restService
      .getConfigs()
      .pipe(
        map((data) => {
          this.IsLoading = false;
          console.log(data);

          return data;
        },
          (error) => {
            console.log(error);
            error = error;
            this.IsLoading = false;
          })).subscribe((p) => this.Configs = p);

  }
  Create() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.width = '90%';
    dialogConfig.autoFocus = true;
    const dialogRef = this.dialog.open(ConfigCreateComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      this.GetConfigs();
    });
  }
  Edit(config: Config) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = config;
    dialogConfig.width = '90%';
    dialogConfig.autoFocus = true;
    const dialogRef = this.dialog.open(ConfigEditComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      this.GetConfigs();
    });
  }
  Remove(config: Config) {
    this.restService.deleteConfig(config.Id)
    .subscribe((result) => {
      console.log(result);
      this.GetConfigs();
    },
    (error) => {console.log(error); });
  }
  ngOnInit() {
    this.GetConfigs();
  }

}
