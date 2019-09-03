import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import UserLogin from '../models/UserLogin';
import UserRegister from '../models/UserRegister';
import { RestService } from './rest.service';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  get currentUserValue(): UserLogin {
    return this.currentUserSubject.value;
  }
  get IsLogin(): boolean {
    return this.currentUserSubject.value !== undefined;
  }
  currentUser: Observable<UserLogin>;

  private readonly currentUserSubject: BehaviorSubject<UserLogin>;

  constructor(private readonly rest: RestService) {
    this.currentUserSubject = new BehaviorSubject<UserLogin>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }
  login(username: string, password: string): any {
    const userLogin = new UserLogin(username, password);

    return this.rest.login(userLogin)
      .pipe(map((user) => {
        if (user && user.Token !== undefined) {

          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject.next(user);
        }
        return user;
      }));
  }
  register(username: string, password: string, email: string): any {
    const registerUser = new UserRegister(username, password, email);
    return this.rest.register(registerUser)
      .pipe(map((user) => {
        if (user && user.Token !== undefined) {
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
