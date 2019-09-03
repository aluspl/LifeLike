import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-registerdialog',
  templateUrl: './registerdialog.component.html',
})
export class RegisterDialogComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  constructor(
    public dialogRef: MatDialogRef<RegisterDialogComponent>,
    private readonly formBuilder: FormBuilder,
    private readonly authenticationService: AuthenticationService,
  ) { }
  onNoClick(): void {
    this.dialogRef.close();
  }
  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      email: ['', Validators.required],
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }

    this.loading = true;
    this.authenticationService.register(this.f.username.value, this.f.password.value, this.f.email.value)
      .pipe(first())
      .subscribe(
        (data) => {
          this.loading = false;
          this.dialogRef.close();

        },
        (error) => {
          this.error = error;
          this.loading = false;
        });
  }
}
