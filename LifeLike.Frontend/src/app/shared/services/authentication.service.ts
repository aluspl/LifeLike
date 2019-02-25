import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import UserLogin from '../models/UserLogin';
import { BehaviorSubject, Observable } from 'rxjs';
import { RestService } from './rest.service';
import UserRegister from '../models/UserRegister';

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
  public get IsLogin(): Boolean {
    return this.currentUserSubject.value!=null;
  }
  login(username: string, password: string): any  {
    var userLogin = new UserLogin(username, password);

    return this.rest.login(userLogin)
      .pipe(map(user => {
        if (user && user.Token != null) {
          console.log(user);

          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject.next(user);
        }
        return user;
      }));
  }
  register(username: string, password: string, email: string): any {
    var registerUser = new UserRegister(username, password, email);
    return this.rest.register(registerUser)
    .pipe(map(user => {
      if (user && user.Token != null) {
        console.log(user);      
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
