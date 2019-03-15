import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import Page from '../../../../shared/models/Page';
import { AdminRestService } from '../../services/admin-rest.service';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { PostEditComponent } from '../post-edit/post-edit.component';
import { PostCreateComponent } from '../post-create/post-create.component';

@Component({
  selector: 'app-admin-pages',
  templateUrl: './pages.component.html',
  styleUrls: ['./pages.component.scss']
})
export class PagesComponent implements OnInit {
  Pages: Page[];
  IsLoading: boolean;
  displayedColumns: string[] = ['Id','ShortName', 'FullName', 'Category', 'Created','Actions'];
  error: any;
  IsEditMode: boolean;
  IsCreateMode: boolean;
  SelectedPage: Page;
  constructor(private restService: AdminRestService, public dialog: MatDialog) { }

  Remove(page: Page): void {
    console.log('Remove');
    console.log(page);
    this.IsLoading= true;
    this.restService.removePost(page.Id)
      .subscribe(
        data => {
          this.IsLoading = false;
          this.GetPages();
      },
      error => {
          this.error = error;
          this.IsLoading = false;
      });
  }
  Edit(page: Page): void {
    console.log('Edit');
    console.log(page);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = page;
    dialogConfig.width = '90%';
    dialogConfig.height = '90%';
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
   this.dialog.open(PostEditComponent, dialogConfig );

  }
  PostCreate() : void {
    console.log('Create');
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '90%';
    dialogConfig.height = '90%';
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
   this.dialog.open(PostCreateComponent, dialogConfig );
  }

  GetPages(): void {
    this.restService.getPages()
      .pipe(
        map((data: Page[]) => {
          this.IsLoading = false;
          return data;
        }))
      .subscribe((p: Page[]) => this.Pages = p);
  }
  ngOnInit() {
    this.GetPages();
  }

}
