import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import UserLogin from '../Models/UserLogin';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  login(login: UserLogin) {
    return this.http.post<any>(`/api/Account/Login`, { login })
        .pipe(map(user => {
            //    public string UserName { get; set; }
        // public string Password { get; set; }
        // public bool RememberMe { get; set; }
            // login successful if there's a jwt token in the response
            if (user && user.token) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(user));
            }

            return user;
        }));
}

logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
}

  constructor(private http: HttpClient) { }
}
