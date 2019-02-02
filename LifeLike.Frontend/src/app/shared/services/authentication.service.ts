import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import UserLogin from '../models/UserLogin';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  login(userdata: UserLogin) {
    return this.http.post<any>(`/api/Account/Login`, { userdata })
        .pipe(map(user => {
            if (user && user.token) {
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
