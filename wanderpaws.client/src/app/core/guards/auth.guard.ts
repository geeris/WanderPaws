// // Protects routes
// //prevent unauthenticated user from visiting the application pages.

// import { inject } from '@angular/core';
// import { Router, CanMatchFn, Route, UrlSegment } from '@angular/router';
// import { AuthService } from '../services/auth.service';
// import { map } from 'rxjs/operators';

// export const AuthGuard: CanMatchFn = (route: Route, _: UrlSegment[]) => {
//     const router = inject(Router);
//     const authService = inject(AuthService);

//     const navigation = router.getCurrentNavigation();

//     const returnUrl = navigation?.extractedUrl.toString() || '/';
//     return authService.user$.pipe(
//         map((user) => {
//             if (user) {
//                 return true;
//             } else {
//                 router.navigate(['login'], {
//                     queryParams: { returnUrl },
//                 });
//                 return false;
//             }
//         })
//     );
// };


import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../../features/auth/services/auth.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private authService: AuthService) {}

  canActivate(): Observable<boolean> {
    const navigation = this.router.getCurrentNavigation();
    const returnUrl = navigation?.extractedUrl.toString() || '/';

    return this.authService.user$.pipe(
      map((user) => {
        if (user) {
          return true;
        } else {
          this.router.navigate(['auth', 'login'], { queryParams: { returnUrl } });
          return false;
        }
      })
    );
  }
}
