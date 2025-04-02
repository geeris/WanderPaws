import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { finalize, Subscription } from 'rxjs';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.css'
})
export class LoginFormComponent implements OnInit, OnDestroy {
  busy = false;
  email = '';
  password = '';
  loginError = false;
  private subscription: Subscription | null = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.subscription = this.authService.user$.subscribe((x) => {
      console.log(this.route.snapshot)
      if (this.route.snapshot.url[0]?.path === 'auth/login') { // chanfge path to check for login later
        const accessToken = localStorage.getItem('access_token');
        const refreshToken = localStorage.getItem('refresh_token');
        if (x && accessToken && refreshToken) {
          const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '';
          this.router.navigate([returnUrl]);
        }
      } // optional touch-up: if a tab shows login page, then refresh the page to reduce duplicate login
    });
  }

  login() {
    if (!this.email || !this.password) {
        return;
    }

    this.busy = true;
    const returnUrl: string = this.route.snapshot.queryParams['returnUrl'] || '/dashboard';

    this.authService
        .login(this.email, this.password)
        .pipe(finalize(() => (this.busy = false)))
        .subscribe({
            next: () => {
              this.router.navigate([returnUrl]);
            }
        });
}

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

  // fb = inject(FormBuilder);
  // http = inject(HttpClient);

  // form = this.fb.nonNullable.group({
  //   username: ['', Validators.required],
  //   password: ['', Validators.required],
  // })

  // login(): void {
  //   this.http.post<{ user: UserInterface }>('https://api.realworld.io/api/users/login', { user: this.form.getRawValue() })
  //     .subscribe(response => {
  //       localStorage.setItem('token', response.user.token);
  //       this.authService.currentUserSignal.set(response.user);
  //       this.router.navigateByUrl('/');
  //       console.log('logged in');
  //     });
  //   console.log(this.form.getRawValue())
  // }

  // logout(): void {
  //   console.log('logout');
  // }
}
