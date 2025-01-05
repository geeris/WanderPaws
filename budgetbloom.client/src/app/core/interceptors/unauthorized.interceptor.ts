import { Injectable } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';

@Injectable()
export class UnauthorizedInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService, private router: Router) { }

    intercept(
        request: HttpRequest<unknown>,
        next: HttpHandler
    ): Observable<HttpEvent<unknown>> {
        if (request.headers.has('skip-interceptor')) {
            console.log('interceptor is skipped')
            // Clone the request and remove the custom header to avoid sending it to the server
            const clonedRequest = request.clone({
                headers: request.headers.delete('skip-interceptor')
            });
            return next.handle(clonedRequest); // Continue without interception
        }
        console.log('interceptor was not skipped')
        return next.handle(request).pipe(
            catchError((err) => {
                if (err.status === 401) {
                    this.authService.clearLocalStorage();
                    console.log('Storage is cleaned - come to check redirect URL')
                    this.router.navigate(['auth/login'], { // change to login later
                        queryParams: { returnUrl: this.router.routerState.snapshot.url },
                    });
                }

                if (!environment.production) {
                    console.error(err);
                }
                const error = (err && err.error && err.error.message) || err.statusText;
                throw Error(error);
            })
        );
    }
}
