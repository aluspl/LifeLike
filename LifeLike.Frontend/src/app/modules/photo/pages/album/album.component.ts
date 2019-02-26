import { Component, OnInit } from '@angular/core';
import Photo from '../../models/Photo';
import { map } from 'rxjs/operators';
import { RestService } from '../../../../shared/services/rest.service';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.scss']
})
export class AlbumComponent implements OnInit {
  IsLoading: boolean;
  Photos: Photo[];

  constructor(private restService: RestService) { }
  GetPhotos() {
    this.IsLoading = true;
    this.restService.GetPhotos()
      .pipe(
        map((data: Photo[]) => {
          this.IsLoading = false;
          console.log(data);
          return data;
        }))
      .subscribe((p: Photo[]) => this.Photos = p);
  }
  ngOnInit() {
    this.GetPhotos();
  }

}
