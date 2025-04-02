import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor() { }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // to add JWT Bearer token to the HTTP request headers
    const accessToken = localStorage.getItem('access_token') ?? '';
    //const isApiUrl = request.url.startsWith(environment.apiUrl); -- what is it???

    // if (accessToken && isApiUrl) {
    if (accessToken) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${accessToken}`
        }
      });
    }

    return next.handle(request);
  }
}