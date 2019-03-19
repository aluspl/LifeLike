import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import Page from '../../../../shared/models/Page';
import { AdminRestService } from '../../services/admin-rest.service';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { PostEditComponent } from '../../dialogs/post-edit/post-edit.component';
import { PostCreateComponent } from '../../dialogs/post-create/post-create.component';


@Component({
  selector: 'app-admin-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.scss']
})
export class PostsComponent implements OnInit {
  Pages: Page[];
  IsLoading: boolean;
  displayedColumns: string[] = ['Id', 'ShortName', 'FullName', 'Category', 'Created', 'Actions'];
  error: any;
  IsEditMode: boolean;
  IsCreateMode: boolean;
  SelectedPage: Page;
  constructor(private restService: AdminRestService, public dialog: MatDialog) { }

  Remove(page: Page): void {
    console.log('Remove');
    console.log(page);
    this.IsLoading = true;
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
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    let dialogRef = this.dialog.open(PostEditComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.GetPages();
    });
  }
  PostCreate(): void {
    console.log('Create');
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.width = '90%';
    dialogConfig.autoFocus = true;
    let dialogRef = this.dialog.open(PostCreateComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.GetPages();
    });
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
