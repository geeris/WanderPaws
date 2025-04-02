import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CreateUser } from '../../models/user.model';
import { NotificationService } from '../../../../core/services/notification.service';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrl: './register-form.component.css'
})
export class RegisterFormComponent {
  user: CreateUser = {
    email: '',
    fullName: '',
    phoneNumber: '',
    password: '',
    confirmPassword: '',
  };

  constructor(
    private authService: AuthService,
    private notificationService: NotificationService,
    private router: Router
  ) { }

  register(): void {
    this.authService.registerUser(this.user).subscribe(
      (response) => {
        this.notificationService.showSuccess(response) // Check why it returns Header: Success, Message: [object][object]
        this.router.navigateByUrl('/')
      }
    )
  }
}
