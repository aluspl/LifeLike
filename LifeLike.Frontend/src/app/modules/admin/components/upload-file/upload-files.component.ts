import { Component, Input, forwardRef } from '@angular/core';
import { AdminRestService } from '../../services/admin-rest.service';
import { HttpEventType } from '@angular/common/http';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-uploadfiles',
  templateUrl: './template.html',
  styleUrls: ['./style.scss'],
  providers: [
  {
    provide: NG_VALUE_ACCESSOR,
    multi: true,
    useExisting: forwardRef(() => UploadFileComponent),
  }]
})
export class UploadFileComponent  implements ControlValueAccessor {

  IsLoading: boolean;
  @Input('value') url: string;
  @Input() placeholder: string;
  IsDisabled: boolean;
  progress: number;
  constructor(private restService: AdminRestService) { }

  // Both onChange and onTouched are functions
  onChange: any = () => { };
  onTouched: any = () => { };

  get value() {
    return this.url;
  }

  set value(val) {
    this.url = val;
    this.onChange(val);
    this.onTouched();
  }
  registerOnChange(fn) {
    this.onChange = fn;
  }

  registerOnTouched(fn) {
    this.onTouched = fn;
  }
  writeValue(value) {
    if (value) {
      this.value = value;
    }
  }

  setDisabledState?(isDisabled: boolean): void {
    this.IsDisabled = isDisabled;
  }

  private PhotoUpload(event) {
    if (event.type === HttpEventType.UploadProgress)
      this.progress = Math.round(100 * event.loaded / event.total);
    else if (event.type === HttpEventType.Response) {
      this.IsLoading = false;
      if (event.status == 200) {
        this.value=event.body;
      }
      else if (event.status != 200) {
        console.log(event);
      }
    }
  }

  upload(files: File[]) {
    this.IsLoading = true;

    if (files.length > 0)
      for (let file of files) {
        this.restService.uploadPhoto(file).subscribe(
        event => {
          this.PhotoUpload(event);
        }
        ,response =>{
          console.log("Error " + response)
        }, ()=>{
          this.IsDisabled=true;
          console.log(this.value);
        });
      }
  }
}
