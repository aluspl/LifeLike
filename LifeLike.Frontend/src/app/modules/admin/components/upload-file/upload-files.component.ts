import { HttpEventType } from '@angular/common/http';
import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { AdminRestService } from '../../services/admin-rest.service';

@Component({
  selector: 'app-uploadfiles',
  templateUrl: './template.html',
  styleUrls: ['./style.scss'],
  providers: [
  {
    provide: NG_VALUE_ACCESSOR,
    multi: true,
    useExisting: forwardRef(() => UploadFileComponent),
  }],
})
export class UploadFileComponent  implements ControlValueAccessor {

  get value() {
    return this.url;
  }

  set value(val) {
    this.url = val;
    this.onChange(val);
    this.onTouched();
  }

  IsLoading: boolean;
  @Input('value') url: string;
  @Input() placeholder: string;
  IsDisabled: boolean;
  progress: number;
  constructor(private readonly restService: AdminRestService) { }

  // Both onChange and onTouched are functions
  onChange: any = () => { };
  onTouched: any = () => { };
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

  upload(files: File[]) {
    this.IsLoading = true;

    if (files.length > 0) {
      for (const file of files) {
        this.restService.uploadPhoto(file).subscribe(
        (event) => {
          this.PhotoUpload(event);
        }
        , (response) => {
        }, () => {
          this.IsDisabled = true;
        });
      }
    }
  }

  private PhotoUpload(event) {
    if (event.type === HttpEventType.UploadProgress) {
      this.progress = Math.round(100 * event.loaded / event.total);
    } else if (event.type === HttpEventType.Response) {
      this.IsLoading = false;
      if (event.status === 200) {
        this.value = event.body;
      } else if (event.status !== 200) {
      }
    }
  }
}
