import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class AuthService {


  public loginRedirectUrl: string;
  public logoutRedirectUrl: string;

  public reLoginDelegate: () => void;

  private previousIsLoggedInCheck = false;
  private _loginStatus = new Subject<boolean>();


  login(arg0: any, arg1: any): any {
    throw new Error('Method not implemented.');
  }

  constructor(private router: Router
    ) {
  }

}
