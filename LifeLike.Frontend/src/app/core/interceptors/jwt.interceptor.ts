import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../../shared/services/authentication.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private readonly authenticationService: AuthenticationService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available
        const currentUser = this.authenticationService.currentUserValue;
        if (currentUser && currentUser.Token) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${currentUser.Token}`,
                },
            });
        }

        return next.handle(request);
    }
}
