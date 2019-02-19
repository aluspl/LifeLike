import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import UserLogin from '../models/UserLogin';
import { BehaviorSubject, Observable } from 'rxjs';
import { RestService } from './rest.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private currentUserSubject: BehaviorSubject<UserLogin>;
  public currentUser: Observable<UserLogin>;

  constructor(private rest: RestService) {
    this.currentUserSubject = new BehaviorSubject<UserLogin>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }
  public get currentUserValue(): UserLogin {
    return this.currentUserSubject.value;
  }
  login(login: UserLogin) {
    return this.rest.login(login)
      .pipe(map(user => {
        if (user && user.token) {
          console.log(user);
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject.next(user);
        }
        return user;
      }));
  }
  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);

  }
}
