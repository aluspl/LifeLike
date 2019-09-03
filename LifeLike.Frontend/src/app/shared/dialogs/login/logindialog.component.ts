import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'dialog-login',
  templateUrl: './logindialog.component.html',
})
export class LoginDialogComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });

    // reset login status
    this.authenticationService.logout();
  }
  get f() { return this.loginForm.controls; }

  constructor(
    public dialogRef: MatDialogRef<LoginDialogComponent>,
    private readonly formBuilder: FormBuilder,
    private readonly authenticationService: AuthenticationService) {

  }
  onNoClick(): void {
    this.dialogRef.close();
  }
  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    this.authenticationService.login(this.f.username.value, this.f.password.value)
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
