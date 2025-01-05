import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { CreateUser } from '../../models/user.model';
import { NotificationService } from '../../../../core/services/notification.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrl: './register-form.component.css'
})
export class RegisterFormComponent {
  user: CreateUser = {
    email: '',
    password: '',
    confirmPassword: '',
  };

  constructor(
    private userService: UserService,
    private notificationService: NotificationService,
    private router: Router
  ) { }

  register(): void {
    this.userService.registerUser(this.user).subscribe(
      (response) => {
        this.notificationService.showSuccess(response.message)
        this.router.navigateByUrl('/')
      }
    )
  }
}
