import { Injectable } from '@angular/core';
import { HttpEvent, HttpRequest, HttpHandler, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ServerErrorInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            catchError((error: HttpErrorResponse) => {
                // Here, you can log the error or handle it as you need
                //console.error("Intercepted error: ", error);

                // Propagate the error to the global error handler
                return throwError(() => error); // This sends the error to the next error handler (GlobalErrorHandler)
            })
        );
    }
}
