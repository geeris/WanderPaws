import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Button, ButtonModule } from 'primeng/button';
import { CheckboxModule } from 'primeng/checkbox';
import { InputTextModule } from 'primeng/inputtext';
import { FloatLabelModule } from 'primeng/floatlabel';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { LoginFormComponent } from './components/login-form/login-form.component';


@NgModule({
  declarations: [RegisterFormComponent, LoginFormComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    
    FormsModule, ReactiveFormsModule,
    ButtonModule, Button,
    CheckboxModule,
    InputTextModule,
    FloatLabelModule,
  ]
})
export class AuthModule { }
